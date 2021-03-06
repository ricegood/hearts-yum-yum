﻿using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {
	public GameObject arrow;
	public GameObject[] menuPanelList;
	public GameObject[] menuList;
	public GameObject[] menuOverList;

	public AudioSource moveSound;
	public AudioSource clickSound;

	private int choose;

	private Vector3 arrowPos = new Vector3(0.9f, 1.15f, 0f);
	private Vector3 arrowOffset = new Vector3 (0f, 0.6f, 0f);

	public static bool popup;

	// Use this for initialization
	void Start () {
		loadKey ();
		popup = false;
		choose = 0;
		activateMenu (choose);
	}
	
	// Update is called once per frame
	void Update () {
		if (!popup) {
			if (Input.GetKeyDown ("up")) {
				deActivateMenu (choose);

				if (choose == 0)
					choose = menuList.Length - 1;
				else
					choose--;

				activateMenu (choose);
			} else if (Input.GetKeyDown ("down")) {
				deActivateMenu (choose);

				if (choose == menuList.Length - 1)
					choose = 0;
				else
					choose++;

				activateMenu (choose);
			} else if (Input.GetKeyDown ("return")) {
				clickSound.Play ();
				switch (choose) {
				case 0:
					popup = true;
					menuPanelList [0].SetActive (true);
					break;
				case 1:
					popup = true;
					menuPanelList [1].SetActive (true);
					break;
				case 2:
					popup = true;
					menuPanelList [2].SetActive (true);
					break;
				case 3:
					Application.Quit ();
					break;
				}
			}
		}
	}

	private void activateMenu(int n){
		moveSound.Play();
		menuList [n].SetActive (false);
		menuOverList [n].SetActive (true);
		arrow.GetComponent<Transform> ().position = arrowPos - n * arrowOffset;
	}

	private void deActivateMenu (int n){
		menuList [n].SetActive (true);
		menuOverList [n].SetActive (false);
	}

	private void loadKey(){
		if (!PlayerPrefs.HasKey ("1LeftKey")) {
			PlayerPrefs.SetString ("1LeftKey", "c");
		}
		if (!PlayerPrefs.HasKey ("1RightKey")) {
			PlayerPrefs.SetString ("1RightKey", "b");
		}
		if (!PlayerPrefs.HasKey ("1JumpKey")) {
			PlayerPrefs.SetString ("1JumpKey", "x");
		}
		if (!PlayerPrefs.HasKey ("1StealKey")) {
			PlayerPrefs.SetString ("1StealKey", "z");
		}
		if (!PlayerPrefs.HasKey ("2LeftKey")) {
			PlayerPrefs.SetString ("2LeftKey", "left");
		}
		if (!PlayerPrefs.HasKey ("2RightKey")) {
			PlayerPrefs.SetString ("2RightKey", "right");
		}
		if (!PlayerPrefs.HasKey ("2JumpKey")) {
			PlayerPrefs.SetString ("2JumpKey", "l");
		}
		if (!PlayerPrefs.HasKey ("2StealKey")) {
			PlayerPrefs.SetString ("2StealKey", "k");
		}
	}
}

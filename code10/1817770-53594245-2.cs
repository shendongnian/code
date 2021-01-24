	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	public class HideVideo : MonoBehaviour
	{
		public GameObject VideoPlayer;
		public bool isPlayerStarted = false;
		void Update() {
			if (isPlayerStarted == false && VideoPlayer.IsPlaying == true) {
				// When the player is started, set this information
				isPlayerStarted = true;
			}
			if (isPlayerStarted == true && VideoPlayer.isPlaying == false ) {
				// Wehen the player stopped playing, hide it
				VideoPlayer.gameObject.SetActive(false);
			}
		}	
	}

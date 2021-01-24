	using UnityEngine;
	using System.Collections.Generic;
	#if PLATFORM_ANDROID
	using UnityEngine.Android;
	#endif
	public class PermissionTest : MonoBehaviour {
		public static bool PermissionCheckInProgress = false;
		private Dictionary<string, string> m_msgTexts = new Dictionary<string, string>();
	#if PLATFORM_ANDROID
		private void OnEnable() {
			App.MsgSystem.MsgSystem.MSG_CONFIRMED.AddListener( HandleAnswer );
		}
		private void OnDisable() {
			App.MsgSystem.MsgSystem.MSG_CONFIRMED.RemoveListener( HandleAnswer );
		}
		private void Start() {
			m_msgTexts.Add( Permission.Camera, "That is why i need the camera." );
			m_msgTexts.Add( Permission.FineLocation, "That is why i need the GPS." );
			m_msgTexts.Add( Permission.ExternalStorageWrite, "That is why i need the SD card." );
			//initial perission request
			foreach (KeyValuePair<string, string> entry in m_msgTexts) {
				if (!Permission.HasUserAuthorizedPermission( entry.Key )) {
					Permission.RequestUserPermission( entry.Key );
				}
			}
		}
		private void Update() {
			if (App.AppManager.Instance._settings._DatenschutzAccepted ) {
				if (!PermissionCheckInProgress) {
					foreach (KeyValuePair<string, string> entry in m_msgTexts) {
						if (entry.Value != "done") {
							AskForPermission( entry.Key, entry.Value );
						}
					}
				}
			}
		}
		private void AskForPermission(string PermissionType, string msg) {
			if (!Permission.HasUserAuthorizedPermission( PermissionType ) && !PermissionCheckInProgress) {
				
				// The user denied permission to use the asked permission type.
				// so send a msg in our msgsystem to ask again with a description why we need it
				// then wait for the answer
				App.MsgSystem.MsgSystem.MSG_PROMPT.Dispatch( msg, PermissionType );
				PermissionCheckInProgress = true;
				m_msgTexts[ PermissionType ] = "done";
			}
		}
		/// <summary>
		/// Callback from the yes or no dialog
		/// </summary>
		/// <param name="handle"></param>
		private void HandleAnswer(string handle) {
			Permission.RequestUserPermission( handle );
			
			PermissionCheckInProgress = false;
		}
	#endif
	}

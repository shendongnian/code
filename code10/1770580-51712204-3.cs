    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;
    
    public class MoviePlay : NetworkBehaviour {
        [SyncVar]
        bool IsPlay = false;
    
        void Update(){
            if(IsPlay){
                Debug.Log("再生中");
            }        
        }
        
        //called when the button is clicked
        public void OnClick(){
            TestNetworkPlayer.local.CmdSendMessageToServer (netId, "ServerOnClick");
        }
        //ONLY called on the server, and then IsPlay should change on all clients as well
        void ServerOnClick(){
            IsPlay = true;
        }
    }

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;
    
    public class PlayerPosition : NetworkBehaviour {
    
        GameObject[] Players;
        Vector3 playerPos;
    	
    	// Update is called once per frame
    	void Update() {
    
            if (!isLocalPlayer)
                return;
                ClientPositionCalls();
    
                if (PlayerCanvas.canvas.hostDotObj.GetComponent<Slider>().value > PlayerCanvas.canvas.clientDotObj.GetComponent<Slider>().value)
                {
                    PlayerCanvas.canvas.WritePositionText("1");
                } else
                {
                    PlayerCanvas.canvas.WritePositionText("2");
                }
        }
    
        [Client]
        void ClientPositionCalls()
        {
            CmdServerPosition();
        }
    
        [Command]
        public void CmdServerPosition()
        {
            playerPos = transform.position;
            RpcPosition(playerPos);
        }
    
        [ClientRpc]
        void RpcPosition(Vector3 pos)
        {
            if (isLocalPlayer)
            {
                PlayerCanvas.canvas.hostDotObj.GetComponent<Slider>().value = transform.position.z;
                playerPos = pos;
            } else
            {
                PlayerCanvas.canvas.clientDotObj.GetComponent<Slider>().value = pos.z;
            }
        }
    }

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Networking;
    
    public class PlayerPosition : NetworkBehaviour {
    
        Vector3 playerPos;
    
        void Update () {
    
            if (!isLocalPlayer)
                return;
    
                ClientPositionCalls();
    
                if(PlayerCanvas.canvas.HostDotUIIndicator.value > PlayerCanvas.canvas.ClientDotUIIndicator.value)
                  {
                     PlayerCanvas.canvas.WritePositionText("1");
                  }
                  else
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
            playerPos = pos;
            if (isLocalPlayer)
            {
                
                PlayerCanvas.canvas.HostDotUIIndicator.value = transform.position.z;
            } 
            else
            {
                PlayerCanvas.canvas.ClientDotUIIndicator.value = pos.z;
            }
        }
    }

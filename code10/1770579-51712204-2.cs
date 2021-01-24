    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;
    public class TestNetworkPlayer : NetworkBehaviour 
    {
	     //a singleton for the CLIENT
	     public static TestNetworkPlayer local;
	     public override void OnStartLocalPlayer ()
	     {
		    base.OnStartLocalPlayer();
		    //so whenever we access TestNetworkPlayer.local,
		    //it will ALWAYS be looking for the LOCAL player on the client we use
		    local = this;
	     }
	    [Command]
	    public void CmdSendMessageToServer(NetworkInstanceId target, string message)
	    {
		    NetworkServer.FindLocalObject(target).SendMessage(message);
	    }
    }

    // This is called by the client
    [Client]
    private void DoSomething()
    {
        if(!isLocalPlayer) return;
    
        // Here we call the command on the server passing our gameObject
        CmdDoSomething(gameObject);
    }
    
    // This is only executed on the server
    // Since the player has a NetworkIdentity the server can identify the correct gameObject we passed
    [Command]
    private void CmdDoSomething (GameObject player)
    {
        // Do stuff that happens only on the server here
        // Now we can send back Information
        // E.g. an int or string again passing the GameObject
        RpcDoSomething(player, "test");
    }
    
    // Usually this would be executed by ALL clients
    // So we have to check if we are the player who originally called the command
    // Again the NetworkIdentity makes sure we can identify the passed GameObject
    [ClientRpc]
    private void RpcDoSomething (GameObject player, string message)
    {
        // For the special case that we are the host (server and client at the same time)
        // we maybe don't want to do something
        // since we probably already did it for ourself before while executing the [Command]
        if(isServer) return;
        // If we are not the one who invoked the command we do nothing
        if(player != gameObject) return;
    
        // I like to put Debug.Log containing "this" in the end so you can click a Log
        // Entry and see exactly where it came from
        Debug.Log("I received: " + message, this);
    }

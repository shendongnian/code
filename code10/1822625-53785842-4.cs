    void Walk()
    {
        //timer
        WalkingTime += Time.deltaTime;
    
        //right leg stepping forward
        if (WalkingTime > 0 && WalkingTime < .4)
        {
    
    
            PlayerRightLeg.transform.rotation = Quaternion.AngleAxis(PlayerRightLeg.transform.rotation.x - (60 * WalkingTime), transform.TransformVector(1, 0, 0));
            PlayerLeftLeg.transform.rotation = Quaternion.AngleAxis(PlayerLeftLeg.transform.rotation.x + (60 * WalkingTime), transform.TransformVector(1, 0, 0));
        }
    
        //left leg stepping forward
        if (WalkingTime > .4 && WalkingTime < 1.2)
        {
            PlayerRightLeg.transform.rotation = Quaternion.AngleAxis(PlayerRightLeg.transform.rotation.x + (60 * (WalkingTime - .8f)), transform.TransformVector(1, 0, 0));
            PlayerLeftLeg.transform.rotation = Quaternion.AngleAxis(PlayerLeftLeg.transform.rotation.x - (60 * (WalkingTime - .8f)), transform.TransformVector(1, 0, 0));
        }
    
        //right leg stepping forward
        if (WalkingTime > 1.2 && WalkingTime < 1.59)
        {
            PlayerRightLeg.transform.rotation = Quaternion.AngleAxis(PlayerRightLeg.transform.rotation.x - (60 * (WalkingTime - 1.6f)), transform.TransformVector(1, 0, 0));
            PlayerLeftLeg.transform.rotation = Quaternion.AngleAxis(PlayerLeftLeg.transform.rotation.x + (60 * (WalkingTime - 1.6f)), transform.TransformVector(1, 0, 0));
        }
    
        //resetting
        if (WalkingTime > 1.6)
        {
            PlayerRightLeg.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            PlayerLeftLeg.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            WalkingTime = 0;
        }
        if(!isLocalPlayer) return;
        // if executed by the local Player invoke the call on the server
        CmdWalk(gameObject);
    }
    // passing the GameObject reference over network works
    // since the player GameObject has a unique identity on all instances
    // namely the NetworkIdentity
    [Command]
    void CmdWalk(GameObject caller)
    {
        Walk();
        RpcWalk(caller);
    }
    
    [ClientRpc]
    void RpcWalk(GameObject caller)
    {
        // skip if server since already done it in CmdWalk
        if(isServer) return;
    
        // skip if this is caller since already done locally
        if(caller == gameObject) return;
    
        Walk();
    }

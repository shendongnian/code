    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    
        if (Input.GetKey(KeyCode.Mouse0))
        {
            CmdBulletFire();
        }
    }

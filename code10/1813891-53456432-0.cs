    [PunRPC]
    void Setting (int someValue)
    {
    I = somevalue;
    }
    void CallSetting()
    {
    PhotonView PV = GetComponent<PhotonView>();
    PV.RPC("Setting", RPCTargets.All, someValue);
    }

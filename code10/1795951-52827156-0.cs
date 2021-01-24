    public void SetInGameRPC(bool inGame) //To be called by masterClient
    {
         var _photonView = this.GetComponent<PhotonView>();
         _photonView.RPC("SetInGame", RpcTarget.All, inGame);
    }

    public void OtherPlayerBlur()
    {
        var _photonView = this.GetComponent<PhotonView>();
        _photonView.RPC("PunCameraBlur", PhotonTarget.Others);
    }
    [PunRPC]
    private void PunCameraBlur()
    {
        // Camera Blur Method Call
    }

    private void Start()
    {
        GameObject[] players = GameObject.FindAllGameObjectsWithTag("Avatar");
        foreach (GameObject player in players)
        {
            if (PhotonView.Get(player).isMine)
            {
                this.target = player.transform;
                break;
            }
        }
    }

    private void Start()
    {
        GameObject[] players = GameObject.FindAllGameObjectsWithTag("Avatar");
        foreach (GameObject player in players)
        {
            if (player.photonView.isMine)
            {
                this.target = player.transform;
                break;
            }
        }
    }

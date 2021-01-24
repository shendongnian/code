    List<GameObject> ListPlayers()
    {
        NetworkManager networkManager = NetworkManager.singleton;
        List<PlayerController> pc = networkManager.client.connection.playerControllers;
    
        List<GameObject> players = new List<GameObject>();
        for (int i = 0; i < pc.Count; i++)
        {
            if (pc[i].IsValid)
                players.Add(pc[i].gameObject);
        }
        return players;
    }

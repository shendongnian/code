    public IList<Player> Players
    {
        get
        {
            return f1.getPlayers.Find(p => p.teamid == teamid).ToList()
        }
    }

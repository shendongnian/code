    public IList<Player> Players
    {
        get
        {
            return f1.getPlayers.Where(p => p.teamid == teamid).ToList()
        }
    }

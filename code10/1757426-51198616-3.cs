    public IList<Player> Players
    {
        get
        {
            var result = new List<Player>();
            foreach (var player in f1.getPlayers.Find(p => p.teamid == teamid))
            {
                result.Add(player);
            }
            return result;
        }
    }

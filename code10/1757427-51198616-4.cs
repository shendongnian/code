    using System.Linq;
    // ...
    public IList<Player> Players
    {
        get
        {
            // Assuming that `.Find(...)` returns an `IEnumerable<Player>`
            return f1.getPlayers.Find(p => p.teamid == teamid).ToList()
        }
    }

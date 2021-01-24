    class MockPlayers
    {
        public IQueryable<Player> Players {get; private set;}
    
        public MockPlayers(Player[] players)
        {
            Players=players.AsQueryable();
        }
    }

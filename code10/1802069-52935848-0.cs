    class Team
    {
        public string TeamName { get; set; }
        public int StadiumName { get; set; }
        public List<Player> Players { get; set; }
        public string Country { get; set; }
    	
    	public IEnumerable<Player> GetPlayers(Func<Player, bool> condition)
    	{
    		return Players.Where(condition);
    	}
    }

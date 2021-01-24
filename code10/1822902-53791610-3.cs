    class Root
    {
        public Dictionary<string, List<int>> MatchStat { get; set; }
        public TeamArrange FirstTeamArrange { get; set; }
        public TeamArrange SecondTeamArrange { get; set; }
    }
    
    class TeamArrange
    {
        public string Tactic { get; set; }
        public List<JToken> PlayerPos { get; set; }
    }
    

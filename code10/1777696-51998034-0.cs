    public class HomeTeamForm
    {
        public string position { get; set; }
        public string points { get; set; }
        public List<string> form { get; set; }
    }
    
    public class HomeTeamInfo
    {
        public string homeTeam { get; set; }
        public string homeGoals { get; set; }
        public string homeGoalsHalfTime { get; set; }
        public string homeCorners { get; set; }
        public string homeYellowCards { get; set; }
        public string homeRedCards { get; set; }
        public string homeShotsGol { get; set; }
        public string homeShotsFora { get; set; }
        public string homeAttacks { get; set; }
        public string homeDangerousAttack { get; set; }
        public string homePossession { get; set; }
        public int homeFouls { get; set; }
        public double avgGoalsHome { get; set; }
        public string teamID { get; set; }
        public HomeTeamForm homeTeamForm { get; set; }
    }
    
    public class AwayTeamForm
    {
        public string position { get; set; }
        public string points { get; set; }
        public List<string> form { get; set; }
    }
    
    public class AwayTeamInfo
    {
        public string awayTeam { get; set; }
        public string awayGoals { get; set; }
        public string awayGoalsHalfTime { get; set; }
        public string awayCorners { get; set; }
        public string awayYellowCards { get; set; }
        public string awayRedCards { get; set; }
        public string awayShotsGol { get; set; }
        public string awayShotsFora { get; set; }
        public string awayAttacks { get; set; }
        public string awayDangerousAttack { get; set; }
        public string awayPossession { get; set; }
        public int awayFouls { get; set; }
        public double avgGoalsAway { get; set; }
        public string teamID { get; set; }
        public AwayTeamForm awayTeamForm { get; set; }
    }
    
    public class Head2head
    {
        public int draws { get; set; }
        public int homeWins { get; set; }
        public int awayWins { get; set; }
        public double avgGolsH2H { get; set; }
    }
    
    public class EventPlayer
    {
        public string playerName { get; set; }
        public string playerShortName { get; set; }
        public string playerID { get; set; }
    }
    
    public class MatchEvent
    {
        public string eventName { get; set; }
        public string eventType { get; set; }
        public string eventTeam { get; set; }
        public int eventTime { get; set; }
        public EventPlayer eventPlayer { get; set; }
        public object eventSubIn { get; set; }
        public object eventSubOut { get; set; }
        public bool eventHomeTeam { get; set; }
    }
    
    public class RootObject : List<RootObject>
    {
        public string timeLive { get; set; }
        public string halfTimeScore { get; set; }
        public object fullTimeScore { get; set; }
        public object firstTeamToScore { get; set; }
        public HomeTeamInfo homeTeamInfo { get; set; }
        public AwayTeamInfo awayTeamInfo { get; set; }
        public Head2head head2head { get; set; }
        public List<MatchEvent> matchEvents { get; set; }
    }

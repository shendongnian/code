    public class Schedules {
        [ForeignKey("Team1Id")]
        public Team Team1 {get;set;}
        [ForeignKey("Team2Id")]
        public Team Team2 {get;set;}
    }

    public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            [InverseProperty("HomeTeam")]
            public ICollection<Game> HomeGames { get; set; }
            
            [InverseProperty("AwayTeam")]
            public ICollection<Game> AwayGames { get; set; }
        }
    
    public class Game
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            
            public int HomeTeamId { get; set; }
            [ForeignKey("HomeTeamId")]
            public Team HomeTeam { get; set; }
    
            public int AwayTeamId{ get; set; }
            [ForeignKey("AwayTeamId")]
            public virtual Team AwayTeam { get; set; }
        }

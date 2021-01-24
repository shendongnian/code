    //The same
    public class Tournament
    {
        [Key]
        public string TournamentID { get; set; }
        public DateTime TournamentDate { get; set; }
        public string Place { get; set; }
    
        [ForeignKey("TeamA")]
        public string TeamAID { get; set; }
        public Team TeamA { get; set; }
    
        [ForeignKey("TeamB")]
        public string TeamBID { get; set; }
        public Team TeamB { get; set; }
    }
    
    public class Team
    {
        [Key]
        public string TeamID { get; set; }
        public string TeamName { get; set; }
        public string Captain { get; set; }
        //Instead of these two
        //[InverseProperty("TeamA")]
        //public virtual ICollection<Tournament> TeamA { get; set; }
    
        //[InverseProperty("TeamB")]
        //public virtual ICollection<Tournament> TeamB { get; set; }
        
        //Let's just include the tournaments this team participated in
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }

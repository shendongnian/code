    public class Transfer
    {
        public int Id { get; set; }
        public DateTime TransferDate { get; set; }
        public Player ThePlayer { get; set; }
        public string PlayerId { get; set; }   
        public Team OldTeam { get; set; }
        [ForeignKey("OldTeam")]
        public int OldTeamId { get; set; }
        public Team NewTeam { get; set; }
        [ForeignKey("NewTeam")]
        public int NewTeamId { get; set; }
    }

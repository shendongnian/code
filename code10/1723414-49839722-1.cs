    public class Team
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<TeamSupport> SupportTeams { get; set; }
        public List<TeamSupport> SupportOfTeams { get; set; } // <--
    }

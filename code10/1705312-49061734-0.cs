    public class TeamVM
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Captain { get; set; }
        public IEnumerable<TournamentVM> Tournaments { get; set; }
    }
    public class TournamentVM
    {
        public string ID { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Competitor { get; set; }
    }

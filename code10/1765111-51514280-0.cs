    public class Visit
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public virtual List<Activity> Activities { get; set; }
    }
    
    
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VisitId { get; set; }
        public virtual Visit Visit { get; set; }
    }

    public class Type1
    {
        public int Type1Id { get; set; }
        public string Property1 { get; set; }
        public string AppUserId {get;set;}//As foreign Key
        public AppUser AppUser { get; set; }
    }

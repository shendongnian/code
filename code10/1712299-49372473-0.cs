    public class Log
    {
        public Log()
        {
            this.Categories = new List<Category>();
        }
        public int ID { get; set; }
        public string Source { get; set; }
        public string Title { get; set; }
        public DateTime Timestamp { get; set; }
        public ICollection<Category> Categories { get; set; }
        
    }
    public class Category
    {
        public int ID { get; set; }
        [ForeignKey("Log")]
        public int LogID { get; set;}
        public string Key { get; set; }
        public string Value { get; set; }
        public Log Log {get; set;}
    }

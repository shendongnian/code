    public class TodoItem 
    {        
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }

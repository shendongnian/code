    public class Quest : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    
        public string Name { get; set; }
    
        public int MaxRepeats { get; set; } 
        [Backlink(nameof(HistoryItem.Quest))]
        public IQueryable<HistoryItem> HistoryItems{ get; }       
    }
    
    public class HistoryItem : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    
        public DateTimeOffset DoneTime { get; set; }
    
        public Quest Quest { get; set; }
    }

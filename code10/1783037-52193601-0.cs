    public class Task
    {
        public int TaskID { get; set; }
    
        public int? PeriodicTaskID { get; set; }
        [ForeignKey("PeriodicTaskID ")]
        public virtual PeriodicTask PeriodicTask { get; set; }
    }

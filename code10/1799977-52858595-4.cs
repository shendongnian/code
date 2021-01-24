    public class GroupIterator
    {        
        public GroupIterator(DateTime scheduledDateTime)
        {
            ScheduledDateTime = scheduledDateTime;
        }
        public DateTime ScheduledDateTime { get; set; }
        public int Count { get; set; }
    }

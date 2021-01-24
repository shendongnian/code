	public class RecipientGroup
    {       
        public RecipientGroup(DateTime scheduledDateTime, IEnumerable<int> recipients)
        {
            ScheduledDateTime= scheduledDateTime;
            Recipients = recipients;
        }
        public DateTime ScheduledDateTime { get; private set; }
        public IEnumerable<int> Recipients { get; private set; }
        public override string ToString()
        {
            return string.Format($"Date: {ScheduledDateTime.ToShortDateString()} {ScheduledDateTime.ToLongTimeString()}, count: {Recipients.Count()}");
        }
    }

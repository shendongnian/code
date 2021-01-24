    public class TerminalDto
    {
        // ... your other properties ...
        public string TimeZoneId { get; set; }
        
        [BsonIgnore]
        public TimeZoneInfo TimeZone
        {
            get
            {
                return TimeZoneInfo.FindSystemTimeZoneById(this.TimeZoneId);
            }
            set
            {
                this.TimeZoneId = value.Id;
            }
        }
    }

    public class DateTimePeriodDto
    {
        public DateTime From {get; set; }
        public DateTime To {get; set; }
        public DateTimePeriodDto(DateTimePeriod dataObject)
        {
            From = dataObject.From ?? //put a default value
            To = dataObject.To ?? //put a default value
        }
    }

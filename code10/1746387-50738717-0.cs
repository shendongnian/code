    public class Recl
    {
        ...    
        public DateTime DataE { get; set; }
    
        public TimeSpan DaysDifference { get { return DateTime.Now - DataE; } }
    }

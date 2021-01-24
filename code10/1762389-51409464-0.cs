    @foreach (var weekday in Model.OfficeHours.WeekdayHours)
    {
        @weekday.Key <br> // Formerly DayDate, now the key of the Dictionary
        @weekday.Value.OpenTime.ToString("hh:mmtt")<br>
        @weekday.Value.CloseTime.ToString("hh:mmtt")
    }
    
    public Dictionary<DateTime,DayHours> WeekdayHours { get; set; } 
    public class DayHours
    {
        public DayHours();
    
        public string DayName { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public bool IsClosed { get; set; }
    }

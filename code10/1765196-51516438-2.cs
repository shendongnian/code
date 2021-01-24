    #region JsonClass
        public class Vevent
        {
            public string uid { get; set; }
            public string dtstamp { get; set; }
            public string status { get; set; }
            public IList<object> dtstart { get; set; }
            public IList<object> dtend { get; set; }
            public string summary { get; set; }
            public string description { get; set; }
        }
        public class Vcalendar
        {
            public string version { get; set; }
            public string prodid { get; set; }
            public IList<Vevent> vevent { get; set; }
        }
        public class iCalendarFile
        {
            public IList<Vcalendar> vcalendar { get; set; }
            public bool success { get; set; }
        }
    #endregion

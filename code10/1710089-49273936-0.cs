    public class Daylist
    {
        public string Day { get; set; }
        public ObservableCollection<TimeTemperature> Temperatures { get; set; }
    }
    public class TimeTemperature
    {
        public string currenttime { get; set; }
        public string winSpeed { get; set; }
        public string humidity { get; set; }
        public string temperature { get; set; }
    }

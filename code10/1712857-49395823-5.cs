    public class Event
    {
        public int Eserc { get; set; }
        public string Type { get; set; }
    }
    public class Sequence
    {
        public ObservableCollection<Event> Events { get; set; }
        public int Freq { get; set; }
    }

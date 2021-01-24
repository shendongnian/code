    public class Waypoint
    {
        public string Label { get; set; }
        public Location Location { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<Waypoint> Waypoints { get; }
            = new ObservableCollection<Waypoint>();
    }

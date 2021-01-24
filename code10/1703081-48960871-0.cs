    public partial class Registration: Window
    {
        public Registration()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            CLocation myLocation = new CLocation();
            myLocation.OnPositionChanged += new EventHandler<PositionEventArgs>(myLocation_OnPositionChanged);
            myLocation.GetLocationEvent();
        }
        private void myLocation_OnPositionChanged(object sender, PositionEventArgs e)
        {
            tbXCoords.Text = (e.Latitude.ToString());
            tbYCoords.Text = (e.Longitude.ToString());
        }
        public class CLocation
        {
            public EventHandler<PositionEventArgs> OnPositionChanged;
            GeoCoordinateWatcher watcher;
            public void GetLocationEvent()
            {
                watcher = new GeoCoordinateWatcher();
                watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
                bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
                if (!started)
                {
                    MessageBox.Show("GeoCoordinateWatcher timed out on start.");
                }
            }
            public void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
            {
                OnPositionChanged?.Invoke(this, new PositionEventArgs() { Latitude = e.Position.Location.Latitude, Longitude = e.Position.Location.Longitude });
            }
        }
    }

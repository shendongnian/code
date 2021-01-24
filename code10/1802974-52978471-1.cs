    public class MainWindowViewModel
    {
        public ObservableCollection<FilterViewModel> Rows { get; }
        public ObservableCollection<string> FilterVehicleEntities { get; }
        public ObservableCollection<string> FilterAttributes { get; set; }
        public MainWindowViewModel()
        {
            Rows = new ObservableCollection<FilterViewModel>();
            FilterVehicleEntities = new ObservableCollection<string>()
            {
                "Vehicle 1",
                "Vehicle 2",
                "Vehicle 3",
            };
            FilterAttributes = new ObservableCollection<string>()
            {
                "Attribute 1",
                "Attribute 2",
                "Attribute 3",
            };
        }
    }

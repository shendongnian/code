    public class StationCollectionVM : INotifyPropertyChanged
    {
        private IStationManager stationManager;
        private ICommand textChanged;
        private IEnumerable<StationVM> stationsVM { get; set; }
    
        public ObservableCollection<StationVM> Stations { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    
        public StationCollectionVM(IStationManager stationManager)
        {
            this.stationManager = stationManager;
            Stations = new ObservableCollection<StationVM>();
            LoadStations();
        }
    
        private async void LoadStations()
        {
            Stations.Clear();
            IEnumerable<Station> stations = await stationManager.GetAllStationsAsync();
            IEnumerator<Station> e = stations.GetEnumerator();
            while (await Task.Factory.StartNew(() => e.MoveNext()))
            {
                stationsVM.Add(new StationVM(stationManager, e.Current));
            }
            Stations = ObservableCollection<StationVM>(stationsVM);
        }
    
        public ICommand TextChanged
        {
            get
            {
                if (textChanged == null)
                {
                    textChanged = new RelayCommand(args =>
                    {
                       if(!string.IsEmpty(args))
                       {
       	                 Stations = staionsVM.Where(x=>x.SomeTextProperty.StartsWith(args));
                       }
                       else
    		           {
                         Stations = ObservableCollection<StationVM>(stationsVM);
    		           }
                    });
                }
                return textChanged;
            }
        }
    }

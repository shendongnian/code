    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            //select 1 and 4 initially:
            MyCollectionOfSelectedIDs = new List<dynamic> { Items[0], Items[3] };
        }
        public IList<DeviceChannelInfo> Items { get; } = new List<DeviceChannelInfo>()
        {
            new DeviceChannelInfo{ name = "1", displayName = "1", id =1 },
            new DeviceChannelInfo{ name = "2", displayName = "2", id =2 },
            new DeviceChannelInfo{ name = "3", displayName = "3", id =3 },
            new DeviceChannelInfo{ name = "4", displayName = "4", id =4 }
        };
        private IEnumerable<dynamic> _mCollectionOfSelectedIDs;
        public IEnumerable<dynamic> MyCollectionOfSelectedIDs
        {
            get { return _mCollectionOfSelectedIDs; }
            set { _mCollectionOfSelectedIDs = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

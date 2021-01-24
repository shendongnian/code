    public class ViewModel: ViewModelBase
    {
        public ViewModel()
        {
            AllChannels = new ObservableCollection<Channel>();
            AllChannels.CollectionChanged += (s,e) =>
               { 
                   RaisePropertyChanged(nameof(InputChannels));
                   RaisePropertyChanged(nameof(OutputChannels));
               }
        }
        private ObservableCollection<Channel> AllChanels { get; }
        public IEnumerable<Channel> InputChannels => AllChannels.Where(c => c.IsInput);
        public IEnumerable<Channel> OutputChannels => AllChannels.Where(c => !c.IsInput);
        public void AddChannel(Channel channel)
        {
            AllChannels.Add(channel);
        }
    }        

    public class ViewModel
    {
        public ViewModel()
        {
            SelectedClusterChanged = new RelayCommand<Cluster>( c => SelectedCluster = c );
        }
        public RelayCommand<Cluster> SelectedClusterChanged { get; private set; } 
        public Cluster SelectedCluster { get; private set; }
    }

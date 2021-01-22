       public partial class Main : Window
        {
            private ObservableCollection<GridNodeProxy> _gridNodes = new ObservableCollection<GridNodeProxy>();
            private static Random _random = new Random();
            public MasterNode MasterNode { get; set; } 
            private ServiceHost _serviceHost;
    
            public Main()
            {
                this.MasterNode = new MasterNode();
                MasterNode.OnMessage += MasterNodeMessage;
    
    
                _serviceHost = new ServiceHost(MasterNode);
                _serviceHost.Open();
    
                InitializeComponent();
    
            }

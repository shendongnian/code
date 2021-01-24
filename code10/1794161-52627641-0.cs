    public partial class MainWindow
    {
        public DeviceInfo DeviceInfo { get; }
    
        public UserInfo UserInfo { get; }
    
        public MainWindow()
        {
            InitializeComponent();
            DeviceInfo = new DeviceInfo();
            UserInfo = new UserInfo();
        }
    }

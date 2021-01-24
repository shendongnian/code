    public partial class MainWindow : Window
    {
        private TaskbarIcon tb; //create as a field to easily access it later
        public MainWindow()
        {
            InitializeComponent();
			this.Visibility = Visibility.Hidden; //Hide the xaml screen
            //initialize NotifyIcon
            tb = (TaskbarIcon)FindResource("MyNotifyIcon");
            tb.Icon = global::MY_ProjectRESX.Properties.Resources.eye1;
		}
    }

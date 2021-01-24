        public partial class MainWindow : Window
        {
         private BackgroundWorker backgroundConnect = new BackgroundWorker();
         public MainWindow()
         {
            InitializeComponent();            
            backgroundConnect = ((BackgroundWorker)this.FindResource("BackgroundConnect"));
            DispatcherTimer reconnectTimer = new DispatcherTimer();
            reconnectTimer.Interval = TimeSpan.FromMilliseconds(500); //Twice per second
            reconnectTimer.Tick += ReconnectTimer_Tick;
            reconnectTimer.Start();
         }
        private void ReconnectTimer_Tick(object sender, EventArgs e)
        {
            /*IPInput and PortInput are names of corresponding textboxes*/
			string InputHost = IPInput.Text;
            int InputPort = int.Parse(PortInput.Text);            
            IPEndPoint InputIPEndpoit = IpTools.GetIPEndPointFromHostName(InputHost, InputPort);	//That's working OK when tested separately
            backgroundConnect.DoWork += BackgroundConnect_DoWork;
            backgroundConnect.RunWorkerCompleted += BackgroundConnect_RunWorkerCompleted;
            if (backgroundConnect.IsBusy == false)                 //In order not to call async twice, or it will throw an exception
                backgroundConnect.RunWorkerAsync(InputIPEndpoit);                
        }        
		/* Handler for clicking of ConnectNow button */
         private void ConnectNow_MouseUp(object sender, MouseButtonEventArgs e)
         {      
            string InputHost = IPInput.Text;
            int InputPort = int.Parse(PortInput.Text);                           
            IPEndPoint InputIPEndpoit = IpTools.GetIPEndPointFromHostName(InputHost, InputPort);                
            backgroundConnect.RunWorkerAsync(InputIPEndpoit);           						//This one is executed correctly when button is clicked
         }       
        /*Works OK on button click*/
		private void BackgroundConnect_DoWork(object sender, DoWorkEventArgs e)
        {            
            IPEndPoint InputIPEndpoit = (IPEndPoint)e.Argument;
            e.Result = SemTCPCommandClient.SendReceiveCommand(InputIPEndpoit, Settings.Default.StringToMicroscopeTM4000);           
        }
        private void BackgroundConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Some UI update                       
        }
	}

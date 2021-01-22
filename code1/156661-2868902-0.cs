        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
            this.MainClient = new Client();
            ClientList.Clients.Add(this.MainClient);
            // Removed LoadXMLFile call here, constructor runs before Loaded event.
            //LoadXMLFile();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            svChat.ServiceReference1.GetIPServiceSoapClient scIpClient = new svChat.ServiceReference1.GetIPServiceSoapClient();
            scIpClient.GetIpCompleted += new EventHandler<svChat.ServiceReference1.GetIpCompletedEventArgs>(IpService_Completed);
          
            scIpClient.GetIpAsync();
        }
        public void IpService_Completed(object sender, svChat.ServiceReference1.GetIpCompletedEventArgs e)
        {
            this.MainClient.Ip = e.Result;
            // Probably where you should call LoadXMLFile
            // at this point the async call has returned and 
            // the ip is intitialized.
            LoadXMLFile();
        }

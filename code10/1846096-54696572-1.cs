     public Form1()
            {
                 ServicePointManager.Expect100Continue = true;
                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                 InitializeComponent();
            }

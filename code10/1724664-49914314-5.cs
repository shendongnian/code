    namespace Client
    {
      public partial class MainForm : Form
      {
        public MainForm()
        {
          InitializeComponent();
    
          RegisterBinaryTcpClientChannel();
        }
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
    
          using (MainForm form = new MainForm())
          {
            Application.Run(form);
          }
        }
      
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>    
        protected override void Dispose(bool disposing)
        {
          if (disposing)
          {
            foreach (IChannel channel in ChannelServices.RegisteredChannels)
            {
              try
              {
                ChannelServices.UnregisterChannel(channel);
              }
              catch (Exception ex)
              {
                Debug.WriteLine("Client.Dispose exception: " + ex);
              }
            }
            if (components != null)
              components.Dispose();
          }
          base.Dispose(disposing);
        }
        private void _btnAccessServer_Click(object sender, EventArgs e)
        {
          try
          {
            var remService = (IHelloRemotingService.IHelloRemotingService)Activator.GetObject(typeof(IHelloRemotingService.IHelloRemotingService), "tcp://localhost:500/Insert.rem");
            remService.Insert("MyName", "MyAddress", "MyEmail", "MyMobile");
          }
          catch (Exception ex)
          {
            MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
    
        private void RegisterBinaryTcpClientChannel(string name = "tcp client")
        {
          IClientChannelSinkProvider firstClientProvider;
          IServerChannelSinkProvider firstServerProvider;
    
          var channelProperties                = new Hashtable();
          channelProperties["name"]            = name;
          channelProperties["typeFilterLevel"] = TypeFilterLevel.Full;
          channelProperties["machineName"]     = Environment.MachineName;
          channelProperties["port"]            = 0; // auto
    
          // create client format provider
          var clientProperties                = new Hashtable();
          clientProperties["typeFilterLevel"] = TypeFilterLevel.Full;
          var clientFormatProvider            = new BinaryClientFormatterSinkProvider(clientProperties, null);
          firstClientProvider                 = clientFormatProvider;
    
          // create server format provider
          var serverFormatProvider             = new BinaryServerFormatterSinkProvider(null, null);
          serverFormatProvider.TypeFilterLevel = TypeFilterLevel.Full;
          firstServerProvider                  = serverFormatProvider;
    
          TcpChannel tcp = new TcpChannel(channelProperties, firstClientProvider, firstServerProvider);
          ChannelServices.RegisterChannel(tcp, false);
        }
      }
    }

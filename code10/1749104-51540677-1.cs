    public partial class Server : Connectable
    {
        #region Constructeurs
        public Server() : this(12221) { }
        public Server(int numPortDefaut)
        {
            InitializeComponent();
            socket = null;
            NewMessage += ShowMessage;
            foreach (IPAddress addr in Dns.GetHostAddresses(Dns.GetHostName()))
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                    numIp.FromString(addr.ToString());
            numPort.Value = numPortDefaut;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                boutonDemarrer.IsEnabled = false;
                MessageBox.Show(this, "Connection impossible - Tic Tac Toe", "Impossible de se connecter à internet. Vérifiez votre connection et réessayez.", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
        }
        #endregion
        public override void Start()
        {
            if (socketListener.IsBound)
            {
                if (socket != null)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Disconnect(false);
                    socket.Dispose();
                    socket = null;
                }
                socketListener.Close();
                socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            try
            {
                socketListener.Bind(new IPEndPoint(IPAddress.Parse(Ip), Port));
                socketListener.Listen(1);
                AcceptConnection();
            }
            catch (SocketException e) { Console.WriteLine(e); }
        }
        public override void Stop()
        {
            acceptConnection.Cancel();
            if (socket != null)
            {
                socketListener.Close();
                socket.Shutdown(SocketShutdown.Both);
                socket.Disconnect(false);
                socket.Dispose();
                socket = null;
            }
        }
        private void AcceptConnection()
        {
            acceptConnection = new CancellationTokenSource();
            new Thread(delegate()
            {
                try
                {
                    while (socket == null)
                    {
                        if (socketListener.Poll(1, SelectMode.SelectRead))
                            socket = socketListener.Accept();
                        acceptConnection.Token.ThrowIfCancellationRequested();
                    }
                    Dispatcher.Invoke(delegate ()
                    {
                        boutonDemarrer.Content = "Jouer";
                        boutonDemarrer.IsEnabled = true;
                    });
                }
                catch (OperationCanceledException e) { Console.WriteLine("Fin de l'attente de connection ({0})", e.Message); }
            }).Start();
        }
        private void ButtonClickStart(object sender, RoutedEventArgs e)
        {
            if ((string)boutonDemarrer.Content == "Jouer")
                Close();
            else if ((string)boutonDemarrer.Content == "Démarrer")
            {
                Start();
                boutonAnnuler.Content = "Stop";
                boutonDemarrer.IsEnabled = false;
                numPort.IsEnabled = false;
            }
        }
        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            if ((string)boutonAnnuler.Content == "Annuler")
                Close();
            else if ((string)boutonAnnuler.Content == "Stop")
            {
                Stop();
                boutonAnnuler.Content = "Annuler";
                boutonDemarrer.Content = "Démarrer";
                boutonDemarrer.IsEnabled = true;
                numPort.IsEnabled = true;
            }
        }
        #region Propriétés
        public string Ip { get { return numIp.ToString(); } }
        public int Port { get { return (int)numPort.Value; } }
        #endregion
        #region Membres
        private Socket socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private CancellationTokenSource acceptConnection = new CancellationTokenSource();
        #endregion
    }

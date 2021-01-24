    public partial class Client : Connectable
    {
        #region Constructeurs
        public Client() : this(string.Empty, 12221) { }
        public Client(string ipDefaut, int portDefaut)
        {
            InitializeComponent();
            NewMessage += ShowMessage;
            numIp.FromString("192.168.2.168");
            numPort.Value = portDefaut;
        }
        #endregion
        public override void Start()
        {
            try
            {
                socket.Connect(Ip, Port);
                boutonConnecter.Content = "Jouer";
                numIp.IsEnabled = false;
                numPort.IsEnabled = false;
                boutonAnnuler.Content = "Déconnecter";
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override void Stop()
        {
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
        }
        private void ButtonClickStart(object sender, RoutedEventArgs e)
        {
            if ((string)boutonConnecter.Content == "Jouer")
                Close();
            else if ((string)boutonConnecter.Content == "Connecter")
            {
                foreach (string num in numIp.ToStringArray())
                    if (num == string.Empty)
                    {
                        ShowMessage("L'adresse ip doit être complète.");
                        return;
                    }
                Start();
            }
        }
        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            if ((string)boutonAnnuler.Content == "Annuler")
                Close();
            else if ((string)boutonAnnuler.Content == "Déconnecter")
            {
                Stop();
                boutonConnecter.IsEnabled = true;
                numIp.IsEnabled = true;
                numPort.IsEnabled = true;
                boutonAnnuler.Content = "Annuler";
                boutonConnecter.Content = "Connecter";
            }
        }
        #region Properties
        public string Ip { get { return numIp.ToString(); } }
        public int Port { get { return (int)numPort.Value; } }
        #endregion
    }

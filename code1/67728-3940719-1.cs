        public Form1()
        {
            InitializeComponent();
            string myHost = System.Net.Dns.GetHostName();
            string myIP = null;
            for (int i = 0; i <= System.Net.Dns.GetHostEntry(myHost).AddressList.Length - 1; i++)
            {
                if (System.Net.Dns.GetHostEntry(myHost).AddressList[i].IsIPv6LinkLocal == false)
                {
                    myIP = System.Net.Dns.GetHostEntry(myHost).AddressList[i].ToString();
                }
            }
        }

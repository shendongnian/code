    namespace test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                Start();
            }
    
            public void Start()
            {
    
                Dns.BeginGetHostEntry("www.google.com", new AsyncCallback(Stop), "Lookin up Google");
            }
    
            public void Stop(IAsyncResult ar)
            {
                IPHostEntry ie = Dns.EndGetHostEntry(ar);
                Console.WriteLine(ie.HostName);
    
                foreach (string adres in ie.Aliases)
                {
                    Console.WriteLine(adres);
                }
            }
        }
    }

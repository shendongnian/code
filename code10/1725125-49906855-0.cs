    public partial class Form1 : Form
    {
        // Declare it here
        private string reply;
        public Form1()
        {
            InitializeComponent();
            WebClient client = new WebClient();
            reply = client.DownloadString("https://pastebin.com/raw/0FHx1t5w");
        }
    }

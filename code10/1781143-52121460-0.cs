    public partial class MainForm : Form
    {
        public string Spieler { get; set; }
        public MainForm()
        {
            InitializeComponent();
            Console.WriteLine("\r\nHello " + Spieler); // I do not get an error here
        }
        public MainForm(string s)
        {
            InitializeComponent();
            this.Spieler = s;
            Console.WriteLine("\r\nHi " + Spieler);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("\r\nHello " + Spieler); // works nicely
        }
    }

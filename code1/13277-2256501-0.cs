    public partial class Form1 : Form
    {
        public ListView Lv
        {
            get { return lvProcesses; }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Utilities ut = new Utilities(this);
        }
    }

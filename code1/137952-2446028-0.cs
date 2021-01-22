    public partial class TimerTester : Form
    {
        public TimerTester()
        {
            InitializeComponent();
        }
        Timer _t1;
        Timer _t2;
        int _it1 = 0, _it2 = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            _t1 = new Timer() { Interval = 1000 };            
            _t1.Tick += new EventHandler(_t1_Tick);
            _t2 = new Timer() { Interval = 2000 };
            _t2.Tick += new EventHandler(_t2_Tick);
            _t1.Start(); _t2.Start();
        }
        void _t1_Tick(object sender, EventArgs e)
        {
            label1.Text = "t1: " + (_it1++).ToString();
        }
        void _t2_Tick(object sender, EventArgs e)
        {
            label2.Text = "t2: " + (_it2++).ToString();
        }        
    }

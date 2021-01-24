    public partial class Form1 : Form
    {
        Timer _timer = new Timer();
        private DateTime _startTime;
        public Form1()
        {
            InitializeComponent();
            
            
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            var span = (DateTime.Now - _startTime);
            label1.Text = string.Format("Elapsed: {0}", span);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            _startTime = DateTime.Now;
            _timer.Start();
            var bgw = new BackgroundWorker();
            bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerAsync();
        }
        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _timer.Stop();
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            // run query here
        }
    }

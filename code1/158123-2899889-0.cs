    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            runItTimer.Interval = 500;
            runItTimer.Tick += new EventHandler(runItTimer_Tick);
            runItTimer.Start();
        }
        private System.Windows.Forms.Timer runItTimer = new System.Windows.Forms.Timer();
        private int v = 0;
        void runItTimer_Tick(object sender, EventArgs e)
        {
            v += 10;
            RunIt();
            if (v == 360) { v = 0; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            runItTimer.Stop();
        }
        private void RunIt()
        {
            label1.Text = v.ToString();
            Refresh();
        }
    }

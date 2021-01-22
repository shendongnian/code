        public partial class Form1 : Form
    {
        int backgroundInt;
        public Form1()
        {
            InitializeComponent();
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = e.UserState as string;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundInt = 1;
            while (backgroundWorker1.CancellationPending == false)
            {
                System.Threading.Thread.Sleep(500);
                backgroundWorker1.ReportProgress(0, 
                    String.Format("I found file # {0}!", backgroundInt));
                backgroundInt++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }

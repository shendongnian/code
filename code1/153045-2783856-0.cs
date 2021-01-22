    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            for (int i = 0; i < 100; i++)
            {
                backgroundWorker.ReportProgress(i);
                Thread.Sleep(100);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.Text = e.ProgressPercentage.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }

    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            for (int i = 0; i < 1000; i++) {
                Thread.Sleep(500);
                backgroundWorker1.ReportProgress(i / 10, "step " + i);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            ResultLog.Text += e.UserState.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }
        private void button1_Click(object sender, EventArgs e) {
            progressBar1.Focus();
            button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            button1.Enabled = true;
            if (e.Error != null) {
                MessageBox.Show(e.Error.Message, "Unexpected error");
            }
        }
    }

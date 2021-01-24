    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            for (int i = 0; i < 1000; i++) {
                Thread.Sleep(500);
                if (backgroundWorker1.CancellationPending) {
                    e.Cancel = true;
                    break;
                }
                backgroundWorker1.ReportProgress(i / 10, "step " + i);
            }
        }
    
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            label1.Text = e.UserState.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }
    
        private void button1_Click(object sender, EventArgs e) {
            cancelButton.Focus();
            button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }
        private void cancelButton_Click(object sender, EventArgs e) {
            backgroundWorker1.CancelAsync();
        }
    
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            button1.Enabled = true;
            if (e.Error != null) {
                MessageBox.Show(e.Error.Message, "Unexpected error");
            }
            if (e.Cancelled) {
                MessageBox.Show("Process stopped by the user", "Cancelled");
            }
            label1.Text = "Press start";
            progressBar1.Value = progressBar1.Minimum;
        }
    
    }

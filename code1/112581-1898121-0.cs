    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnStart_Click(object sender, EventArgs e)
            {
                backgroundWorker.RunWorkerAsync();
            }
    
            private void btnStop_Click(object sender, EventArgs e)
            {
                backgroundWorker.CancelAsync();
            }
    
            private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker worker = (BackgroundWorker)sender;
    
                int countValue = 0;
                int max = 100000000;
                for (int i = 0; i < max; i++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
    
                    countValue = i;
                    if (i % 1000000 == 0)
                        worker.ReportProgress(i / (max / 100), i);
                }
                worker.ReportProgress(100, max);
            }
    
            private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar.Value = e.ProgressPercentage;
                labelCounter.Text = ((int)e.UserState).ToString();
            }
        }
    }

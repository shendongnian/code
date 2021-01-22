    using System;
    using System.Threading;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
                backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
                backgroundWorker1.WorkerReportsProgress = backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.RunWorkerAsync();
            }
            bool mCancel;
            void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
                if (e.Error != null) MessageBox.Show(e.Error.ToString());
                if (mCancel) this.Close();
            }
            protected override void OnFormClosing(FormClosingEventArgs e) {
                if (backgroundWorker1.IsBusy) mCancel = e.Cancel = true;
                backgroundWorker1.CancelAsync();
            }
            void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
                label1.Text = e.UserState as string;
            }
            void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
                Stopwatch sw = Stopwatch.StartNew();
                while (!backgroundWorker1.CancellationPending) {
                    TimeSpan ts = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    backgroundWorker1.ReportProgress(0, elapsedTime);
                    Thread.Sleep(15);
                }
            }
        }
    }

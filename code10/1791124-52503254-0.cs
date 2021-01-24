    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    namespace BackgroundWorkerExample
    {
      public partial class Form1 : Form
      {
        private BackgroundWorker worker;
        public Form1()
        {
          InitializeComponent();
          this.worker = new BackgroundWorker();
          this.worker.DoWork += Worker_DoWork;
          this.worker.ProgressChanged += Worker_ProgressChanged;
          this.worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
          this.worker.WorkerReportsProgress = true;
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => this.button1.Enabled = true;
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
          this.textBox1.Text = e.ProgressPercentage.ToString();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
          for (int i = 0; i <= 10; i++)
          {
            this.worker.ReportProgress(i);
            // do work
            Thread.Sleep(1000);
          }
        }
        private void button1_Click(object sender, EventArgs e)
        {
          this.button1.Enabled = false;
          this.worker.RunWorkerAsync();
        }
      }
    }

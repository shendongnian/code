    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    
    class MyForm : Form
    {
        BackgroundWorker worker;
        ListView list;
        Button btn;
        ProgressBar bar;
        public MyForm()
        {
            Text = "Loader";
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            list = new ListView();
            list.Dock = DockStyle.Fill;
            Controls.Add(list);
            btn = new Button();
            btn.Text = "Load";
            btn.Dock = DockStyle.Bottom;
            Controls.Add(btn);
            btn.Click += btn_Click;
            bar = new ProgressBar();
            bar.Dock = DockStyle.Top;
            Controls.Add(bar);
        }
    
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn.Enabled = true;
        }
    
        void btn_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
            btn.Enabled = false;
        }
    
    
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                string newRow = "Row " + i.ToString();
                worker.ReportProgress(i, newRow);
                Thread.Sleep(100);
            }
        }
    
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            list.Items.Add((string)e.UserState);
            bar.Value = e.ProgressPercentage;
        }
    
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MyForm());
        }
    }

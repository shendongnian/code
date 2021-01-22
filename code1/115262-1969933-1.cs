    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    namespace SerialSample
    {
        public partial class Form1 : Form
        {
            private BackgroundWorker _BackgroundWorker;
            private Random _Random;
            public Form1()
            {
                InitializeComponent();
                _ProgressBar.Style = ProgressBarStyle.Marquee;
                _ProgressBar.Visible = false;
                _Random = new Random();
                InitializeBackgroundWorker();
            }
            private void InitializeBackgroundWorker()
            {
                _BackgroundWorker = new BackgroundWorker();
                _BackgroundWorker.WorkerReportsProgress = true;
                _BackgroundWorker.DoWork += (sender, e) => ((MethodInvoker)e.Argument).Invoke();
                _BackgroundWorker.ProgressChanged += (sender, e) =>
                    {
                        _ProgressBar.Style = ProgressBarStyle.Continuous;
                        _ProgressBar.Value = e.ProgressPercentage;
                    };
                _BackgroundWorker.RunWorkerCompleted += (sender, e) =>
                {
                    if (_ProgressBar.Style == ProgressBarStyle.Marquee)
                    {
                        _ProgressBar.Visible = false;
                    }
                };
            }
            private void buttonStart_Click(object sender, EventArgs e)
            {
                _BackgroundWorker.RunWorkerAsync(new MethodInvoker(() =>
                    {
                        _ProgressBar.BeginInvoke(new MethodInvoker(() => _ProgressBar.Visible = true));
                        for (int i = 0; i < 1000; i++)
                        {
                            Thread.Sleep(10);
                            _BackgroundWorker.ReportProgress(i / 10);
                        }
                    }));
            }
        }
    }

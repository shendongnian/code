    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Threading
    {
        public partial class FormMain : Form
        {
            private BackgroundWorker _BackgroundWorker;
            private Queue<Func<string>> _Commands;
            private Random _Random;
    
            public FormMain()
            {
                InitializeComponent();
    
                _Random = new Random();
                _Commands = new Queue<Func<string>>();
                _BackgroundWorker = new BackgroundWorker();
    
                _BackgroundWorker.WorkerReportsProgress = true;
                _BackgroundWorker.WorkerSupportsCancellation = true;
                _BackgroundWorker.DoWork += backgroundWorker_DoWork;
                _BackgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
                _BackgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
                _BackgroundWorker.RunWorkerAsync();
            }
    
            private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                while (!_BackgroundWorker.CancellationPending)
                {
                    if (_Commands.Count > 0)
                    {
                        AddMessage("Starting waiting job...");
                        AddMessage(_Commands.Dequeue().Invoke());
                    }
                    Thread.Sleep(1);
                }
            }
    
            void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar.Value = e.ProgressPercentage;
            }
    
            private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                AddMessage("BackgroundWorker doesn't make any further jobs.");
            }
    
            private void buttonStart_Click(object sender, EventArgs e)
            {
                _Commands.Enqueue(DoSomething);
                //or maybe with a lambda
                //_Commands.Enqueue(new Func<string>(() =>
                //{
                //    string message;
                //    message = DoSomething();
                //    return message;
                //}));
            }
    
            private string DoSomething()
            {
                int max = 10;
                for (int i = 1; i <= max; i++)
                {
                    Thread.Sleep(_Random.Next(10, 1000));
                    
                    if (_BackgroundWorker.CancellationPending)
                    {
                        return "Job aborted!";
                    }
    
                    AddMessage(String.Format("Currently working on item {0} of {1}", i, max));
                    _BackgroundWorker.ReportProgress((i*100)/max);
                }
    
                return "Job is done.";
            }
    
            private void AddMessage(string message)
            {
                if (textBoxOutput.InvokeRequired)
                {
                    textBoxOutput.BeginInvoke(new Action<string>(AddMessageInternal), message);
                }
                else
                {
                    AddMessageInternal(message);
                }
            }
    
            private void AddMessageInternal(string message)
            {
                textBoxOutput.AppendText(String.Format("{0:G}   {1}{2}", DateTime.Now, message, Environment.NewLine));
    
                textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
                textBoxOutput.ScrollToCaret();
            }
    
            private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (_BackgroundWorker.IsBusy)
                {
                    _BackgroundWorker.CancelAsync();
                    e.Cancel = true;
    
                    AddMessage("Please close only if all jobs are done...");
                }
            }
        }
    }

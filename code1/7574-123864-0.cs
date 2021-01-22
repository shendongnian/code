    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;
    namespace WindowsFormsApplication1
    {
        public class AsyncForm : Form
        {
            private Button _startButton;
            private Label _statusLabel;
            private Button _stopButton;
            private MyWorker _worker;
            public AsyncForm()
            {
                var layoutPanel = new TableLayoutPanel();
                layoutPanel.Dock = DockStyle.Fill;
                layoutPanel.ColumnStyles.Add(new ColumnStyle());
                layoutPanel.ColumnStyles.Add(new ColumnStyle());
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                _statusLabel = new Label();
                _statusLabel.Text = "Idle.";
                layoutPanel.Controls.Add(_statusLabel, 0, 0);
                _startButton = new Button();
                _startButton.Text = "Start";
                _startButton.Click += HandleStartButton;
                layoutPanel.Controls.Add(_startButton, 0, 1);
                _stopButton = new Button();
                _stopButton.Enabled = false;
                _stopButton.Text = "Stop";
                _stopButton.Click += HandleStopButton;
                layoutPanel.Controls.Add(_stopButton, 1, 1);
                this.Controls.Add(layoutPanel);
            }
            private void HandleStartButton(object sender, EventArgs e)
            {
                _stopButton.Enabled = true;
                _startButton.Enabled = false;
                
                _worker = new MyWorker() { WorkerSupportsCancellation = true };
                _worker.RunWorkerCompleted += HandleWorkerCompleted;
                _worker.RunWorkerAsync();
                
                _statusLabel.Text = "Running...";
            }
            private void HandleStopButton(object sender, EventArgs e)
            {
                _worker.CancelAsync();
                _statusLabel.Text = "Cancelling...";
            }
            private void HandleWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled)
                {
                    _statusLabel.Text = "Cancelled!";
                }
                else
                {
                    _statusLabel.Text = "Completed.";
                }
                _stopButton.Enabled = false;
                _startButton.Enabled = true;
            }
        }
        public class MyWorker : BackgroundWorker
        {
            protected override void OnDoWork(DoWorkEventArgs e)
            {
                base.OnDoWork(e);
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    if (this.CancellationPending)
                    {
                        e.Cancel = true;
                        e.Result = false;
                        return;
                    }
                }
                e.Result = true;
            }
        }
    }
    
If you *really really* don't want your method to exit, I'd suggest putting a flag like an AutoResetEvent on a derived BackgroundWorker, then override OnRunWorkerCompleted to set the flag.  It's still kind of kludgy though; I'd recommend treating the cancel event like an asynchronous method and do whatever it's currently doing in the RunWorkerCompleted handler.

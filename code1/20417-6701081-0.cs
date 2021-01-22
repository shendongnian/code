    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    namespace LoginWithProgressBar
    {
        public partial class TheForm : Form
        {
            // BackgroundWorker object deals with the long running task
            private readonly BackgroundWorker _bw = new BackgroundWorker();
            public TheForm()
            {
                InitializeComponent();
                // set MarqueeAnimationSpeed
                progressBar.MarqueeAnimationSpeed = 30;
                // set Visible false before you start long running task
                progressBar.Visible = false;
                _bw.DoWork += Login;
                _bw.RunWorkerCompleted += BwRunWorkerCompleted;
            }
            private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                // hide the progress bar when the long running process finishes
                progressBar.Hide();
            }
            private void Login(object sender, DoWorkEventArgs doWorkEventArgs)
            {
                // emulate long (3 seconds) running task
                Thread.Sleep(3000);
                // hide progress bar after long running task finishes
                progressBar.Hide();
            }
            private void ButtonLoginClick(object sender, EventArgs e)
            {
                // show the progress bar when the associated event fires (here, a button click)
                progressBar.Show();
                // start the long running task async
                _bw.RunWorkerAsync();
            }
        }
    }    

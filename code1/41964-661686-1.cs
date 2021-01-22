    using System;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace Test
    {
        public partial class UIThread : Form
        {
            Worker worker;
    
            Thread workerThread;
    
            public UIThread()
            {
                InitializeComponent();
                worker = new Worker();
                worker.ProgressChanged += new EventHandler<ProgressChangedArgs>(OnWorkerProgressChanged);
                workerThread = new Thread(new ThreadStart(worker.StartWork));
                workerThread.Start();
            }
    
            private void OnWorkerProgressChanged(object sender, ProgressChangedArgs e)
            {
                //cross thread - so you don't get the cross theading exception
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        OnWorkerProgressChanged(sender, e);
                    });
                    return;
                } 
    
                //change control
                this.label1.Text = e.Progress;
            }
        }
    
        public class Worker
        {
            public event EventHandler<ProgressChangedArgs> ProgressChanged;
            
            protected void OnProgressChanged(ProgressChangedArgs e)
            {
                if(ProgressChanged!=null)
                {
                    ProgressChanged(this,e);
                }
            }
    
            public void StartWork()
            {
                Thread.Sleep(100);
                OnProgressChanged(new ProgressChangedArgs("Progress Changed"));
                Thread.Sleep(100);
            }
        }
    
        public class ProgressChangedArgs : EventArgs 
        {
            public string Progress {get;private set;}
            public ProgressChangedArgs(string progress)
    	    {
                Progress = progress;
    	    }
        }
    }

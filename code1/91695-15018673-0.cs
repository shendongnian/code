    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    using System.Diagnostics;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Thread workerThread = null;
            ManualResetEvent threadInterrupt = new ManualResetEvent(false);
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                if (this.workerThread == null)
                {
                    this.threadInterrupt.Reset();
                    this.workerThread = new Thread(() =>
                    {
                        int i = 0;
                        while (!this.threadInterrupt.WaitOne(0))
                        {
                            Debug.Print("put your code in here while worker thread running.. " + i.ToString());
                            Thread.Sleep(100);
                            i++;
                        }
                        this.workerThread = null;
                        // worker thread finished in here..
                    });
                    this.workerThread.IsBackground = true;
                    // start worker thread in here
                    this.workerThread.Start();
                }
                else
                {
                    // stop worker thread in here
                    threadInterrupt.Set();
                }
            }
        }
    }

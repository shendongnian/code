    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp4
    {
        public partial class Form1 : Form
        {
            private bool _stopRequested = false;
            private TimeSpan _interval = TimeSpan.FromMinutes(1);
            private readonly object _monitorLock = new object();
            private Thread _thread = null;
    
            public Form1()
            {
                InitializeComponent();
    
                ThreadStart threadStart = new ThreadStart(this.DoWork);
                _thread = new Thread(threadStart);
            }
    
            void DoWork()
            {
                while (!_stopRequested)
                {
                    lock (_monitorLock)
                    {
                        //Do Processing, whilst Checking for whether stop requested has been set. If it has return out.
                        for (int i = 0; i < 100; i++)
                        {
                            if (_stopRequested) return;
    
                            Debug.WriteLine($"Processing: {i}");
    
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                        }
    
                        Monitor.Wait(_monitorLock, _interval);
                    }
                }
            }
    
            public void RequestStart()
            {
                _stopRequested = false;
    
                _thread.Start();
                
            }
    
            public void RequestStop()
            {
                _stopRequested = true;
    
                //Lock the monitor object
                lock (_monitorLock)
                {
                    //Pulse the monitor lock to release it
                    Monitor.Pulse(_monitorLock);
                }
            }
    
            private void btnStart_Click(object sender, EventArgs e)
            {
                this.RequestStart();
            }
    
            private void btnStop_Click(object sender, EventArgs e)
            {
                this.RequestStop();
            }
        }
    }

    using System;
    using System.Threading;
    using System.Windows.Threading;
    
    namespace BeginInvoke2
    {
        public partial class Window1
        {
            public Window1()
            {
                InitializeComponent();
                ThreadPool.QueueUserWorkItem(Proc, Dispatcher);
            }
    
            private void Proc(object state)
            {
                var disp = (Dispatcher) state;
                var tid = Thread.CurrentThread.ManagedThreadId.ToString();
                // Use BeginInvoke to do the operations on the UI thread
                disp.BeginInvoke((Action)(() => 
                {
                    x_tid1.Text = "threadpool thread: " + Thread.CurrentThread.ManagedThreadId.ToString();
                    x_tid2.Text = "        ui thread: " + tid;
                }));
    
                // Can't do the following operations because we are not in the UI
                // thread
                //x_text.Text = "In Proc";
                //x_tid.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            }
        }
    }

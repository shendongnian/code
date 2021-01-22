    using System;
    using System.Threading;
    using System.Windows.Threading;
    
    namespace BeginInvoke
    {
        public partial class Window1
        {
            public Window1()
            {
                InitializeComponent();
                x_tid.Text = Thread.CurrentThread.ManagedThreadId.ToString();
    
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += timer_Tick;
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
            }
    
            private void timer_Tick(object sender, EventArgs e)
            {
                Thread.SpinWait(900);
                x_text.Text = DateTime.Now.ToString();
                x_tid.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            }
        }
    }

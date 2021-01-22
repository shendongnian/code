    using System;
    using System.Windows.Forms;
    
    namespace SimpleHiddenWinform
    {
        internal class HiddenForm : Form
        {
            private Timer _timer;
            private ApplicationContext _ctx;
    
            public HiddenForm(ApplicationContext ctx)
            {
                _ctx = ctx;
                _timer = new Timer()
                {
                    Interval = 5000, //5 second delay
                    Enabled = true
                };
                _timer.Tick += new EventHandler(_timer_Tick);
            }
    
            void _timer_Tick(object sender, EventArgs e)
            {
                //tell the main message loop to quit
                _ctx.ExitThread();
            }
        }
    
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var ctx = new ApplicationContext();
                var frmHidden = new HiddenForm(ctx);
                //pass the application context, not the form
                Application.Run(ctx);
            }
        }
    }

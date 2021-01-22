    using System;
    using System.Windows.Forms;
    class MyForm : Form {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new MyForm());
        }
    
        Timer timer;
        MyForm() {
            timer = new Timer();
            count = 10;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Start();
        }
        protected override void Dispose(bool disposing) {
            if (disposing) {
                timer.Dispose();
            }
            base.Dispose(disposing);
        }
        int count;
        void timer_Tick(object sender, EventArgs e) {
            Text = "Wait for " + count + " seconds...";
            count--;
            if (count == 0)
            {
                timer.Stop();
            }
        }
    }

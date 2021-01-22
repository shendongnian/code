    using System.Windows.Forms;
    using System.Threading;
    using System;
    class MyForm : Form
    {
        
        public MyForm()
        {
            Button btn = new Button();
            Controls.Add(btn);
            btn.Text = "Go";
            btn.Click += btn_Click;
        }
        int counter;
        void btn_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Interlocked.Increment(ref counter);
                ThreadPool.QueueUserWorkItem(DoWork, i);
            }
        }
        void DoWork(object state)
        {
            for (int i = 0; i < 10; i++)
            { // send progress
                BeginInvoke((Action)delegate { Text += state.ToString(); });
                Thread.Sleep(500);
            }
            EndThread(); // this thread done
        }
        void EndThread()
        {
            if (Interlocked.Decrement(ref counter) == 0)
            {
                AllDone();
            }
        }
        void AllDone()
        {
            Invoke((Action)delegate { this.Text += " all done!"; });
        }
        [STAThread]
        static void Main()
        {
            Application.Run(new MyForm());
        }
    }

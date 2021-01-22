    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    class Demo : Form
    {
        class ChattyWorker : BackgroundWorker
        {
            ~ChattyWorker()
            {
                Console.WriteLine("Worker finalized");
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
    
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += delegate
            {
                Console.WriteLine("Collecting...");
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            };
            timer.Start();
    
            ChattyWorker worker = new ChattyWorker();
            worker.DoWork += delegate
            {
                Console.WriteLine("Worker starting");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(250);
                    Console.WriteLine(i);
                }
                Console.WriteLine("Worker exiting");
            };
            worker.RunWorkerAsync();
        }
        [STAThread]
        static void Main()
        { // using a form to force a sync context
            Application.Run(new Demo());
        }
    }

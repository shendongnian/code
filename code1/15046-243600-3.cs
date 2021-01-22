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
        class SomeTarget
        {
            ~SomeTarget()
            {
                Console.WriteLine("Target finalized");
            }
            public SomeTarget()
            {
                Console.WriteLine("Target created");
            }
            public void Foo(object sender, EventArgs args)
            {
                Console.WriteLine("Foo");
            }
        }
        static void Collect(object sender, EventArgs args)
        {
            Console.WriteLine("Collecting...");
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
    
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += Collect;
            timer.Start();
    
            ChattyWorker worker = new ChattyWorker();
            worker.RunWorkerCompleted += new SomeTarget().Foo;
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

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            static List<Thread> threads = new List<Thread>();
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                for (int i = 0; i < 10; i++)
                {
                    StartThread();
                    System.Threading.Thread.Sleep(500);
                }
                //kill each thread so the app will exit, otherwise, the app won't close
                //until all forms are manually closed...
                threads.ForEach(t => t.Abort());
            }
            static void StartThread()
            {
                Thread t = new Thread(ShowForm);
                threads.Add(t);
                t.Start();
            }
            static void ShowForm()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }

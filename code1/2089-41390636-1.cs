    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace Sample
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                //simple add Diagnostics namespace, and these 3 lines below 
                string thisprocessname = Process.GetCurrentProcess().ProcessName;
                if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                    return;
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Sample());
            }
        }
    }

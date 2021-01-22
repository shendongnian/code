    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2 {
        static class Program {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main() {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 form1 = new Form1();
                Application.ThreadException += new ThreadExceptionEventHandler(form1.UnhandledThreadExceptionHandler);
                Application.Run(form1);
            }
        }
    }

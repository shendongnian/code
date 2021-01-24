    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace TwoForms
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                // If you do it this way you'll have to stop the application yourself
                // Form1 TheForm = new Form1();  
                // Application.Run();
    
                Application.Run(new Form1());   // When Form1 is closed, the application will exit.
            }
        }
    }

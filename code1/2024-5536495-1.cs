    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using SingleInstanceController_NET;
    
    namespace SingleInstance
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static Form CreateForm()
            {
                return new Form1(); // Form1 is used for the main window.
            }
    
            static void OnStartNextInstance(Form mainWindow) // When the user tries to restart the application again,
                                                             // the main window is activated again.
            {
                mainWindow.WindowState = FormWindowState.Maximized;
            }
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);            
                SingleInstanceController controller = new SingleInstanceController(CreateForm, OnStartNextInstance);
                controller.Run(new string[0]);         
            }
        }
    }

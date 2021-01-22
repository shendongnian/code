    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                Application.EnterThreadModal += new EventHandler(Application_EnterThreadModal);
                Application.LeaveThreadModal += new EventHandler(Application_LeaveThreadModal);
    
                Application.Run(new Form1());
            }
    
            private static void Application_EnterThreadModal(object sender, EventArgs e)
            {
                IsModalDialogOpen = true;
            }
    
            private static void Application_LeaveThreadModal(object sender, EventArgs e)
            {
                IsModalDialogOpen = false;
            }
    
            public static bool IsModalDialogOpen { get; private set; }
        }
    }

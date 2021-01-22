    using System;
    using System.Windows.Forms;
    // needs reference to Microsoft.VisualBasic
    using Microsoft.VisualBasic.ApplicationServices;  
    namespace YourNamespace
    {
        public class SingleInstanceController : WindowsFormsApplicationBase
        {
            public SingleInstanceController()
            {
                this.IsSingleInstance = true;
            }
            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs e)
            {
                e.BringToForeground = true;
                base.OnStartupNextInstance(e);
            }
            protected override void OnCreateMainForm()
            {
                this.MainForm = new Form1();
            }
        }
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                string[] args = Environment.GetCommandLineArgs();
                SingleInstanceController controller = new SingleInstanceController();
                controller.Run(args);
            }
        }
    }

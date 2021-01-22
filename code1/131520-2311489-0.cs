    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
    
    namespace TestSolution
    {
        sealed class Program : WindowsFormsApplicationBase
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] commandLine)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                var program = new Program()
                {
                    IsSingleInstance = Properties.Settings.Default.IsSingleInstance
                };
                // Here you can perform whatever you want to perform in the second instance
                // After Program.Run the control will be passed to the first instance    
                program.Run(commandLine);
            }
    
            protected override void OnCreateMainForm()
            {
                MainForm = new ImportForm();
            }
    
            protected override bool OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
            {
                // This code will run in the first instance
    
                return base.OnStartupNextInstance(eventArgs);
            }
        }
    }

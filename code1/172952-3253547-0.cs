    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                new MyApp().Run(args);
            }
        }
        public class MyApp : WindowsFormsApplicationBase
        {
            protected override void OnCreateSplashScreen()
            {
                this.SplashScreen = new Form2();
            }
            protected override void OnCreateMainForm()
            {
                // Do your initialization here
                //...
                System.Threading.Thread.Sleep(5000);  // Test
                // Then create the main form, the splash screen will automatically close
                this.MainForm = new Form1();
            }
        }
    }

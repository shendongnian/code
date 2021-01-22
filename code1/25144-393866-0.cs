    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
    
    namespace WindowsFormsApplication1 {
      static class Program {
        [STAThread]
        static void Main(string[] args) {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          new MyApp().Run(args);
        }
      }
      class MyApp : WindowsFormsApplicationBase {
        protected override void OnCreateSplashScreen() {
          this.SplashScreen = new frmSplash();
        }
        protected override void OnCreateMainForm() {
          // Do your time consuming stuff here...
          //...
          System.Threading.Thread.Sleep(3000);
          // Then create the main form, the splash screen will close automatically
          this.MainForm = new Form1();
        }
      }
    }

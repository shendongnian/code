    using System;
    using System.Windows.Forms;
    
    namespace Example
    {
        internal static class Program
        {
            [STAThread]
            private static void Main()
            {
                new Bootstrapper().Run();
            }
        }
    
        public class Bootstrapper
        {
            public void Run()
            {
                // [Application initialization here]
                ShowView();
            }
    
            private static void ShowView()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }

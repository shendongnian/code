    using System;
    using System.Windows.Forms;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += MyUnhandledExceptionHandler;
        
            // start rest of application
        }
        
        private static void MyUnhandledExceptionHandler(object sender, EventArgs args)
        {
            MessageBox.Show("Your app is crashing.  Watch out!");
        }
    }

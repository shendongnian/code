    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        static class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(args.Contains("-minimized")));
            }
        }
    }

    using System;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var args = new string[] { Assembly.GetExecutingAssembly().Location, "/run" };
                NUnit.Gui.AppEntry.Main(args);
            }
        }
    }

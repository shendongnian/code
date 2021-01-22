    using System;
    using System.Windows.Forms;
    using micautLib;
    namespace MathInputPanel
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MathInputControl ctrl = new MathInputControlClass();
                ctrl.EnableExtendedButtons(true);
                ctrl.Show();
                ctrl.Close += () => Application.ExitThread();
                Application.Run();
            }
        }
    }

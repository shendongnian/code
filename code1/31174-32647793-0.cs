    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    namespace ConsoleWriter
    {
        static class Program
        {
            [DllImport("kernel32.dll")]
            private static extern bool AttachConsole(int dwProcessId);
            private const int ATTACH_PARENT_PROCESS = -1;
            [STAThread]
            static void Main(string[] args)
            {
                if(args.Length > 0 && args[0].ToUpperInvariant() == "/NOGUI")
                {
                    AttachConsole(ATTACH_PARENT_PROCESS);
                    Console.WriteLine(Environment.NewLine + "This line prints on console.");
                    Console.WriteLine("Exiting...");
                    SendKeys.SendWait("{ENTER}");
                    Environment.Exit(0);
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }
        }
    }

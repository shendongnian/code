    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    namespace WindowsAndConsoleApp
    {
      static class Program
      {
        const uint WM_CHAR = 0x0102;
        const int VK_ENTER = 0x0D;
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // Do this first.
                AttachConsole(ATTACH_PARENT_PROCESS);
                Console.Title = "Console Window - Enter Key Test";
                Console.WriteLine("Getting the handle of the currently executing console window...");
                IntPtr cw = GetConsoleWindow();
                Console.WriteLine($"Console handle: {cw.ToInt32()}");
                Console.WriteLine("\nPut some windows in from of this one...");
                Thread.Sleep(5000);
                Console.WriteLine("Take your time...");
                Thread.Sleep(5000);
                Console.WriteLine("Sending the Enter key now...");
                // Send the Enter key to the console window no matter where it is.
                SendMessage(cw, WM_CHAR, (IntPtr)VK_ENTER, IntPtr.Zero);
                // Do this last.
                FreeConsole();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
      }
    }
 

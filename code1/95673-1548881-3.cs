    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    
    namespace WindowsFormsApplication10
    {
      static class Program
      {
    
        const int SWP_NOSIZE = 0x0001;
    
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
    
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();
    
        [STAThread]
        static void Main()
        {
          AllocConsole();
          IntPtr MyConsole = GetConsoleWindow();
          int xpos = 1024;
          int ypos = 0;
          SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
          Console.WindowLeft=0;
          Console.WriteLine("text in my console");
    
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1());
        }
      }
    }

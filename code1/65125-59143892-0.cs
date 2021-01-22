    using System;
    using System.Runtime.InteropServices;
    
    class Program
    {
      [DllImport("user32.dll")]
      static extern int SetWindowText(IntPtr hWnd, string text);
    
      static void Main(string[] args)
      {
        using (System.Diagnostics.Process p = new System.Diagnostics.Process())
        {
          p.StartInfo = new System.Diagnostics.ProcessStartInfo()
          {
            FileName = @"notepad.exe",
            Arguments = @""
          };
    
          string window_title = "notepad demo";
          p.Start();
          System.Threading.SpinWait.SpinUntil(() => p.MainWindowHandle != IntPtr.Zero);
          SetWindowText(p.MainWindowHandle, window_title);
          p.WaitForExit();
        }
      }
    }

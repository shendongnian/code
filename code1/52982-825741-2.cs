    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace TextSendKeys
    {
        class Program
        {
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            static void Main(string[] args)
                {
                    Process notepad = new Process();
                    notepad.StartInfo.FileName = @"C:\Windows\Notepad.exe";
                    notepad.Start();
        
                    // Need to wait for notepad to start
                    notepad.WaitForInputIdle();
        
                    IntPtr p = notepad.MainWindowHandle;
                    ShowWindow(p, 1);
                    SendKeys.SendWait("ABC");
                }
        }
    }

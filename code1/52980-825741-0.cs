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
    
                // Need to wait for notepad to run, 100 ms works on my machine
                System.Threading.Thread.Sleep(100);
    
                IntPtr p = notepad.MainWindowHandle;
                ShowWindow(p, 1);
                System.Windows.Forms.SendKeys.SendWait("ABC");
            }
        }
    }

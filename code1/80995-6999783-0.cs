    class Program
    {
        static void Main(string[] args)
        {
            PrintDocument(@"C:\test.docx", 2);
            Console.ReadKey();
        }
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        private static void PrintDocument(string name, int copies)
        {
            var process = System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = name,
                UseShellExecute = true
            });
            process.WaitForInputIdle();
            SetForegroundWindow(process.MainWindowHandle);
            SendKeys.SendWait("^p"); // send CTRL+P
            SendKeys.SendWait(copies.ToString()); // send number of copies
            SendKeys.SendWait("~"); // send ENTER
            // -- or send all in one
            //SendKeys.SendWait(string.Format("^p{0}~", copies));
        }
    }

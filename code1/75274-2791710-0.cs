    class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            
            foreach (var process in processes)
            {
                Console.WriteLine("Process Name: {0} ", process.ProcessName); 
                if (process.ProcessName == "WINWORD")
                {
                    IntPtr handle = process.MainWindowHandle;
                    bool topMost =  SetForegroundWindow(handle); 
                }
            }
    }
}

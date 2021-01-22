    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
        static void Main(string[] args)
        {
            var hWnd = FindWindow(null, "Untitled - Notepad");
            if (hWnd != IntPtr.Zero)
            {
                Console.WriteLine("window found");
            }
            else
            {
                Console.WriteLine("No window with given title has been found");
            }
        }
    }

    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);
        private static void Main()
        {
            Point mouse = default;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                GetCursorPos(out mouse);
            }
            else
            {
                // How to do on Linux and OSX?
            }
            Console.WriteLine($"Mouse X:{mouse.X} Y:{mouse.Y}");
        }
    }

    public class Program
    {
        public static void ToggleTitleBar(long hwnd, bool showTitle)
        {
            long style = GetWindowLong(hwnd, -16L);
            if (showTitle)
                style |= 0xc00000L;
            else
                style &= -12582913L;
            SetWindowLong(hwnd, -16L, style);
            SetWindowPos(hwnd, 0L, 0L, 0L, 0L, 0L, 0x27L);
        }
        public static void Main()
        {
            Guid guid = Guid.NewGuid();
            string oldTitle = Console.Title;
            Console.Title = guid.ToString();
            int hwnd = FindWindow("ConsoleWindowClass", guid.ToString());
            Console.Title = oldTitle;
            Console.WriteLine("Press enter to hide title");
            Console.ReadLine();
            ToggleTitleBar(hwnd, false);
            Console.WriteLine("Press enter to show title");
            Console.ReadLine();
            ToggleTitleBar(hwnd, true);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
        [DllImport("user32", EntryPoint = "GetWindowLongA")]
        public static extern long GetWindowLong(long hwnd, long nIndex);
        [DllImport("user32", EntryPoint = "SetWindowLongA")]
        public static extern long SetWindowLong(long hwnd, long nIndex, long dwNewLong);
        [DllImport("user32")]
        public static extern long SetWindowPos(long hwnd, long hWndInsertAfter, long x, long y, long cx, long cy,
                                               long wFlags);
        [DllImport("User32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
    }

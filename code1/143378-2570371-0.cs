    using System;
    using System.Runtime.InteropServices;
    namespace ExplorerZap
    {
        class Program
        {
            [DllImport("user32.dll")]
            public static extern int FindWindow(string lpClassName, string lpWindowName);
            [DllImport("user32.dll")]
            public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);
            static void Main(string[] args)
            {
                int hwnd;
                hwnd = FindWindow("Progman", null);
                PostMessage(hwnd, /*WM_QUIT*/ 0x12, 0, 0);
                return;
            }
        }
    }

        [DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SETREDRAW = 0xB;
        public static void SuspendDrawing(Control target)
        {
            SendMessage(target.Handle, WM_SETREDRAW, 0, 0);
        }
        public static void ResumeDrawing(Control target, bool redraw)
        {
            SendMessage(target.Handle, WM_SETREDRAW, 1, 0);
            if (redraw)
            {
                target.Refresh();
            }
        }

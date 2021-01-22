    public class YourForm : Form
    {
        private const int WM_HOTKEY = 0x0312;
    
        [Flags]
        private enum MOD : uint
        {
            MOD_ALT = 0x0001,
            MOD_CONTROL = 0x0002,
            MOD_SHIFT = 0x0004,
            MOD_WIN = 0x0008
        }
    
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, MOD fsModifiers, uint vk);
    
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        protected override WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                // Your code here
            }
        }
    }

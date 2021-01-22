    public class KeyboardHook
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        public enum Modifiers
        {
            None = 0x0000,
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Win = 0x0008
        }
        int modifier;
        int key;
        IntPtr hWnd;
        int id;
        public KeyboardHook(int modifiers, Keys key, Form f)
        {
            this.modifier = modifiers;
            this.key = (int)key;
            this.hWnd = f.Handle;
            id = this.GetHashCode();
        }
        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }
        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }
        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }

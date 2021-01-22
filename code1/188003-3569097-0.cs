    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
      public class HotKeyManager
      {
        public static event EventHandler<HotKeyEventArgs> HotKeyPressed;
    
        public static int RegisterHotKey(Keys key, KeyModifiers modifiers)
        {
          int id = System.Threading.Interlocked.Increment(ref _id);
          RegisterHotKey(_wnd.Handle, id, (uint)modifiers, (uint)key);
          return id;
        }
    
        public static bool UnregisterHotKey(int id)
        {
          return UnregisterHotKey(_wnd.Handle, id);
        }
    
        protected static void OnHotKeyPressed(HotKeyEventArgs e)
        {
          if (HotKeyManager.HotKeyPressed != null)
          {
            HotKeyManager.HotKeyPressed(null, e);
          }
        }
    
        private static MessageWindow _wnd = new MessageWindow();
    
        private class MessageWindow : Form
        {
          protected override void WndProc(ref Message m)
          {
            if (m.Msg == WM_HOTKEY)
            {
              HotKeyEventArgs e = new HotKeyEventArgs(m.LParam);
              HotKeyManager.OnHotKeyPressed(e);
            }
    
            base.WndProc(ref m);
          }
    
          private const int WM_HOTKEY = 0x312;
        }
    
        [DllImport("user32")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
    
        [DllImport("user32")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
        private static int _id = 0;
      }
    
      
      public class HotKeyEventArgs : EventArgs
      {
        public readonly Keys Key;
        public readonly KeyModifiers Modifiers;
    
        public HotKeyEventArgs(Keys key, KeyModifiers modifiers)
        {
          this.Key = key;
          this.Modifiers = modifiers;
        }
    
        public HotKeyEventArgs(IntPtr hotKeyParam)
        {
          uint param = (uint)hotKeyParam.ToInt64();
          Key = (Keys)((param & 0xffff0000) >> 16);
          Modifiers = (KeyModifiers)(param & 0x0000ffff);
        }
      }
    
      [Flags]
      public enum KeyModifiers
      {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8,
        NoRepeat = 0x4000
      }
    

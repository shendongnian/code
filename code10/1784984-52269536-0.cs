     class KeyHandle
     {
        private static Int32 WM_KEYDOWN = 0x100;
        private static Int32 WM_KEYUP = 0x101;
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, int Msg, 
       System.Windows.Forms.Keys wParam, int lParam);
     public static void SendKey(IntPtr hWnd, System.Windows.Forms.Keys key)
      {
          PostMessage(hWnd, WM_KEYDOWN, key, 0);
       }
     }

     [DllImport("user32.dll", SetLastError = true)]
     [return: MarshalAs(UnmanagedType.Bool)]
     static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
     [StructLayout(LayoutKind.Sequential)]
     private struct RECT
     {
         public int Left;
         public int Top;
         public int Right;
         public int Bottom;
      }

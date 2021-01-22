      const int WM_USER = 0x400;
      const int PBM_SETSTATE = WM_USER + 16;
      const int PBM_GETSTATE = WM_USER + 17;
    
      [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
      static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    
      public enum ProgressBarStateEnum : int
      {
       Normal = 1,
       Error = 2,
       Paused = 3,
      }
    
      public static ProgressBarStateEnum GetState(this ProgressBar pBar)
      {
       return (ProgressBarStateEnum)(int)SendMessage(pBar.Handle, PBM_GETSTATE, IntPtr.Zero, IntPtr.Zero);
      }
    
      public static void SetState(this ProgressBar pBar, ProgressBarStateEnum state)
      {
       SendMessage(pBar.Handle, PBM_SETSTATE, (IntPtr)state, IntPtr.Zero);
      } 

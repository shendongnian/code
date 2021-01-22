    using System.Runtime.InteropServices;
    
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, ProgressBarState state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
    public enum ProgressBarState
    {
        Normal = 1,  // Green
        Error = 2,   // Red
        Warning = 3, // Yellow
    }

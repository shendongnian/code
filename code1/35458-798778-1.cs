    public static class ThreadingHelper_NativeMethods
    {
       [DllImport("user32.dll")]
       public static extern bool IsGUIThread(bool bConvert);
    }

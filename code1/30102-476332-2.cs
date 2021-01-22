    [DllImport("CoreDll.dll")]
    public static extern void MessageBeep(int code);
    
    public static void MessageBeep() {
      MessageBeep(-1);  // Default beep code is -1
    }

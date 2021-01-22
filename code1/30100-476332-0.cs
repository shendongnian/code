    [DllImport("CoreDll.dll")]
    public static void extern MessageBeep(int code);
    
    public static void MessageBeep() {
      MessageBeep(-1);  // Default beep code is -1
    }

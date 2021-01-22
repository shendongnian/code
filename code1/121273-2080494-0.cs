    public struct KBDLLHOOKSTRUCT
    {
      public Int32 vkCode;
      public Int32 scanCode;
      public Int32 flags;
      public Int32 time;
      public IntPtr dwExtraInfo;
    }
    private static IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
    {
      if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
      {
        KBDLLHOOKSTRUCT kbd = (KBDLLHOOKSTRUCT) Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
        Debug.WriteLine(kbd.vkCode);  // ***** your code here *****
      }
      return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

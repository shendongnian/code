    byte[] keyboardState = new byte[256];
    GetKeyboardState(keyboardState);
    IntPtr handle = GetKeyboardLayout(0);
    uint scanCode = MapVirtualKeyEx(VirtualKeyCode, 0, handle);
    StringBuilder stringBuilder = new StringBuilder(2);
    int nResultLower = ToUnicodeEx(VirtualKeyCode, scanCode, keyboardState, stringBuilder,
                                           stringBuilder.Capacity, 0, handle);
    string output= string.Empty;
    if (nResultLower != 0)
    {
      output = stringBuilder.ToString();
    }

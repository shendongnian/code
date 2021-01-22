    [DllImport("user32.dll")]
    public static extern int GetKeyboardState(byte [] lpKeyState);
    ...
    byte[] bCharData = new byte[256];
    GetKeyboardState(bCharData);

    [DllImport("user32.dll")] public static extern int GetKeyboardState(byte[] lpKeyState);
    private void myFunc()
    {
        byte[] keyboardState = new byte[255];
        int keystate = GetKeyboardState(keyboardState);
        if (keyboardState[(int)Keys.Back] == 128)
        {
           // backspace still pressed
           return;
        }
        else if (keyboardState[(int)Keys.Delete] == 128)
        {
           // Delete key still pressed
           return;
        }
        // More processor intensive code ...
    }

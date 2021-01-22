    private static IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            //Console.WriteLine((Keys)vkCode);
            if (vkCode == (int)Keys.OemOpenBrackets))
            {
                SendKeys.Send("ë");                   
                return 1;
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

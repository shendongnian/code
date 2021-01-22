        namespace KeyboardHook
        {
            public class Hooker
            {
        
                [StructLayout(LayoutKind.Sequential)]
                public struct KBDLLHOOKSTRUCT
                {
                    public int vkCode;
                    public int scanCode;
                    public int flags;
                    public int time
    
    ;
                public int extraInfo;
            }
    
            public delegate int HookProc(int nCode, int wParam, IntPtr ptrKBDLLHOOKSTRUCT);
    
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook, HookProc callBack, IntPtr hMod, int threadId);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
            public static extern int CallNextHookEx(IntPtr hhk, int nCode, int wParam, IntPtr lParam);
    
            private static IntPtr kbh_Handle;
            private static HookProc kbh_HookProc;
    
            private const int VK_SNAPSHOT = 0x2C;
            private const int WM_KEYDOWN = 0x0100;
            private const int WM_SYSKEYDOWN = 0x0104;
            private const int WH_KEYBOARD_LL = 13;
    
            private static int LowLevelKeyboardProc(int nCode, int wParam, IntPtr lParam)
            {
                if (nCode < 0)
                {
                    CallNextHookEx(kbh_Handle, nCode, wParam, lParam);
                    return 0;
                }
    
                if (wParam == WM_KEYDOWN)
                {
                    IntPtr kbdll = lParam;
                    KBDLLHOOKSTRUCT kbdllstruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(kbdll, typeof(KBDLLHOOKSTRUCT));
    
                    if (kbdllstruct.vkCode == VK_SNAPSHOT)
                        return -1;
    
                }
    
                return CallNextHookEx(kbh_Handle, nCode, wParam, lParam);
            }
    
            public static void HookKeyboard()
            {
                try
                {
                    kbh_HookProc = LowLevelKeyboardProc;
    
                    kbh_Handle = SetWindowsHookEx(WH_KEYBOARD_LL, kbh_HookProc, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
    
                    if (kbh_Handle != IntPtr.Zero)
                        System.Diagnostics.Debug.WriteLine(String.Format("It worked! HookHandle: {0}", kbh_Handle));
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("ERROR: {0}", ex.Message));
                }
            }
        }
    }
    

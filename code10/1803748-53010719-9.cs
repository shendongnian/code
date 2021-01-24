        public static class MouseHook
        {
            public static event EventHandler MouseAction = delegate { };
            public static event MouseEventHandler MouseWheell = delegate { };
    
            public const int INPUT_MOUSE = 0;
    		public const uint MOUSEEVENTF_WHEEL = 0x0800;
    		
    public static void Start()
    {
        _hookID = SetHook(_proc);
    }
    public static void stop()
    {
        UnhookWindowsHookEx(_hookID);
    }
    
    private static LowLevelMouseProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;
    
    private static IntPtr SetHook(LowLevelMouseProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            IntPtr hook = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
            if (hook == IntPtr.Zero) throw new System.ComponentModel.Win32Exception();
            return hook;
        }
    }
    
    private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    
    private static IntPtr HookCallback(
      int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
        {
            MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
            MouseAction(null, new EventArgs());
        }
        if (nCode >= 0 && MouseMessages.WM_MOUSEWHEEL == (MouseMessages) wParam)
        {
            MSLLHOOKSTRUCT lparam = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
            int wheelvalue = (Int16)(lparam.mouseData >> 16) < 0 ? -120 : 120; // Forward = 120, Backward = -120
            //MouseWheell(null,new MouseEventArgs());
    
        		var input = new INPUT[1];
        		input[0].type = INPUT_MOUSE;
        		input[0].mi = MouseInput(0, 0, (uint)wheelvalue, 0, MOUSEEVENTF_WHEEL);
        		SendInput(1, input, Marshal.SizeOf(input[0].GetType()));
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
    
    private const int WH_MOUSE_LL = 14;
    
    private MOUSEINPUT MouseInput(int x, int y, uint data, uint t, uint flag)
    {
        return new MOUSEINPUT { dx = x, dy = y, mouseData = data, time = t, dwFlags = flag };
    }
    private enum MouseMessages
    {
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_MOUSEMOVE = 0x0200,
        WM_MOUSEWHEEL = 0x020A,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205
    }
    
    [StructLayout(LayoutKind.Sequential)]
    private struct POINT
    {
        public int x;
        public int y;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    private struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public uint mouseData;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT
    {
        [FieldOffset(0)]
        public int type;
        [FieldOffset(4)]
        public MOUSEINPUT mi;
        [FieldOffset(4)]
        public KEYBDINPUT ki;
        [FieldOffset(4)]
        public HARDWAREINPUT hi;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
 
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }
   
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern uint SendInput(uint num_inputs, INPUT[] inputs, int size);
    
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook,
      LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
      IntPtr wParam, IntPtr lParam);
    
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
    }

    public static void ClickSomePoint()
    {
        var point = new Point(20, 35);
        // Set the cursor position
        System.Windows.Forms.Cursor.Position = point;
		
        DoClickMouse(0x2); // Left mouse button down
        DoClickMouse(0x4); // Left mouse button up
    }
	
    static void DoClickMouse(int mouseButton)
    {
        var mouseInput = new MOUSEINPUT()
        {
            dwFlags = mouseButton
        };
			
        var input = new INPUT()
        {
            dwType = 0, // Mouse input
            mi = mouseInput
        };
		
        var size = Marshal.SizeOf(input);
		
        if (SendInput(1, input, size) == 0)
        { 
            throw new Exception();
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    struct MOUSEINPUT
    {
        int dx;
        int dy;
        int mouseData;
        public int dwFlags;
        int time;
        IntPtr dwExtraInfo;
    }
	
    struct INPUT
    {
        public uint dwType;
        public MOUSEINPUT mi;
    }
	
    [DllImport("user32.dll", SetLastError=true)]
    static extern uint SendInput(uint cInputs, INPUT input, int size);

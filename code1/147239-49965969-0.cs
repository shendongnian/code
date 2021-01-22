	[StructLayout(LayoutKind.Sequential)]
	public struct NativeMessage
	{
		public IntPtr handle;
		public uint msg;
		public IntPtr wParam;
		public IntPtr lParam;
		public uint time;
		public System.Drawing.Point p;
	}
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	[DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool PeekMessage(out NativeMessage message,
		IntPtr handle, uint filterMin, uint filterMax, uint flags);
	public const int PM_NOREMOVE = 0;
	public const int PM_REMOVE = 0x0001;
	protected void MouseHooker()
	{
		NativeMessage msg;
		using (Process curProcess = Process.GetCurrentProcess())
		{
			using (ProcessModule curModule = curProcess.MainModule)
			{
				// Install the low level mouse hook that will put events into _mouseEvents
				_hookproc = MouseHookCallback;
				_hookId = User32.SetWindowsHookEx(WH.WH_MOUSE_LL, _hookproc, Kernel32.GetModuleHandle(curModule.ModuleName), 0);
			}
		}
		while (true)
		{
			while (PeekMessage(out msg, IntPtr.Zero,
				(uint)WM.WM_MOUSEFIRST, (uint)WM.WM_MOUSELAST, PM_NOREMOVE))
				;
			Thread.Sleep(10);
		}            
	}
	
	...
	Thread _mouseHookThread = new Thread(MouseHooker);
	_mouseHookThread.IsBackground = true;
	_mouseHookThread.Priority = ThreadPriority.Highest;
	_mouseHookThread.Start();
	

		public Form1()
		{
			InitializeComponent();
			Thread thread = new Thread(HookThread);
			thread.IsBackground = true;
			thread.Start();
		}
		private void HookThread()
		{
			_hookProc = new HookProc(HookFunction);
			using (Process curProcess = Process.GetCurrentProcess())
			using (ProcessModule curModule = curProcess.MainModule)
			{
				_hook = SetWindowsHookEx(HookType.WH_MOUSE_LL, _hookProc, GetModuleHandle(curModule.ModuleName), 0);// (uint)AppDomain.GetCurrentThreadId());
			}
			//Application.AddMessageFilter(this);
			Application.Run();
		}
		
		private IntPtr HookFunction(int code, IntPtr wParam, IntPtr lParam)
		{
			if (code < 0)
			{
				//you need to call CallNextHookEx without further processing
				//and return the value returned by CallNextHookEx
				return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
			}
			
			int msg = wParam.ToInt32();
			string messages = string.Join(", ", _messageMapping.Where(t => t.Item1 == msg).Select(t => t.Item2));
			if (string.IsNullOrWhiteSpace(messages))
				messages = msg.ToString();
			Trace.WriteLine($"Messages: { messages }");
			//return the value returned by CallNextHookEx
			return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
		}

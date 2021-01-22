    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace Your.Utility
    {
    	public class KeyBordHook
    	{
    		private const int WM_KEYDOWN = 0x100;
    		private const int WM_KEYUP = 0x101;
    		private const int WM_SYSKEYDOWN = 0x104;
    		private const int WM_SYSKEYUP = 0x105;
    
    		//Global event 
    		public event KeyEventHandler OnKeyDownEvent;
    		public event KeyEventHandler OnKeyUpEvent;
    		public event KeyPressEventHandler OnKeyPressEvent;
    
    		private static int hKeyboardHook = 0;
    
    		private const int WH_KEYBOARD_LL = 13; //keyboard hook constant
    
    		private HookProc KeyboardHookProcedure; // declare keyhook event type
    
    		//declare keyhook struct 
    		[StructLayout(LayoutKind.Sequential)]
    		public class KeyboardHookStruct
    		{
    			public int vkCode;
    			public int scanCode;
    			public int flags;
    			public int time;
    			public int dwExtraInfo;
    		}
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    		private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    		private static extern bool UnhookWindowsHookEx(int idHook);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    		private static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
    
    		[DllImport("user32")]
    		private static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);
    
    		[DllImport("user32")]
    		private static extern int GetKeyboardState(byte[] pbKeyState);
    
    		[DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    		private static extern IntPtr GetModuleHandle(string lpModuleName);
    
    		private delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
    
    		private List<Keys> preKeys = new List<Keys>();
    
    
    		public KeyBordHook()
    		{
    			Start();
    		}
    
    		~KeyBordHook()
    		{
    			Stop();
    		}
    
    		public void Start()
    		{
    			//install keyboard hook 
    			if (hKeyboardHook == 0)
    			{
    				KeyboardHookProcedure = new HookProc(KeyboardHookProc);
    				//hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
    				Process curProcess = Process.GetCurrentProcess();
    				ProcessModule curModule = curProcess.MainModule;
    
    				hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, GetModuleHandle(curModule.ModuleName), 0);
    
    				if (hKeyboardHook == 0)
    				{
    					Stop();
    					throw new Exception("SetWindowsHookEx ist failed.");
    				}
    			}
    		}
    
    		public void Stop()
    		{
    			bool retKeyboard = true;
    
    			if (hKeyboardHook != 0)
    			{
    				retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
    				hKeyboardHook = 0;
    			}
    			//if unhook failed 
    			if (!(retKeyboard)) throw new Exception("UnhookWindowsHookEx failed.");
    		}
    
    		private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
    		{
    
    			if ((nCode >= 0) && (OnKeyDownEvent != null || OnKeyUpEvent != null || OnKeyPressEvent != null))
    			{
    				KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
    
    				if ((OnKeyDownEvent != null || OnKeyPressEvent != null) && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
    				{
    					Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
    					if (IsCtrlAltShiftKeys(keyData) && preKeys.IndexOf(keyData) == -1)
    					{
    						preKeys.Add(keyData);
    					}
    				}
    
    				if (OnKeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
    				{
    					Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
    					KeyEventArgs e = new KeyEventArgs(GetDownKeys(keyData));
    
    					OnKeyDownEvent(this, e);
    				}
    
    				if (OnKeyPressEvent != null && wParam == WM_KEYDOWN)
    				{
    					byte[] keyState = new byte[256];
    					GetKeyboardState(keyState);
    
    					byte[] inBuffer = new byte[2];
    					if (ToAscii(MyKeyboardHookStruct.vkCode,
    					MyKeyboardHookStruct.scanCode,
    					keyState,
    					inBuffer,
    					MyKeyboardHookStruct.flags) == 1)
    					{
    						KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
    						OnKeyPressEvent(this, e);
    					}
    				}
    
    				if ((OnKeyDownEvent != null || OnKeyPressEvent != null) && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
    				{
    					Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
    					if (IsCtrlAltShiftKeys(keyData))
    					{
    
    						for (int i = preKeys.Count - 1; i >= 0; i--)
    						{
    							if (preKeys[i] == keyData)
    							{
    								preKeys.RemoveAt(i);
    							}
    						}
    
    					}
    				}
    
    				if (OnKeyUpEvent != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
    				{
    					Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
    					KeyEventArgs e = new KeyEventArgs(GetDownKeys(keyData));
    					OnKeyUpEvent(this, e);
    				}
    			}
    			return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
    		}
    
    		private Keys GetDownKeys(Keys key)
    		{
    			Keys rtnKey = Keys.None;
    			foreach (Keys keyTemp in preKeys)
    			{
    				switch (keyTemp)
    				{
    					case Keys.LControlKey:
    					case Keys.RControlKey:
    						rtnKey = rtnKey | Keys.Control;
    						break;
    					case Keys.LMenu:
    					case Keys.RMenu:
    						rtnKey = rtnKey | Keys.Alt;
    						break;
    					case Keys.LShiftKey:
    					case Keys.RShiftKey:
    						rtnKey = rtnKey | Keys.Shift;
    						break;
    					default:
    						break;
    				}
    			}
    			rtnKey = rtnKey | key;
    
    			return rtnKey;
    		}
    
    		private Boolean IsCtrlAltShiftKeys(Keys key)
    		{
    
    			switch (key)
    			{
    				case Keys.LControlKey:
    				case Keys.RControlKey:
    				case Keys.LMenu:
    				case Keys.RMenu:
    				case Keys.LShiftKey:
    				case Keys.RShiftKey:
    					return true;
    				default:
    					return false;
    			}
    		}
    	}
    }

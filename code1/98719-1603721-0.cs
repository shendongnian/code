using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
	class Form1 : Form
	{
		public Form1()
		{
			var newWindowBtn = new Button { Text = "New Window" };
			newWindowBtn.Click += (s, e) => new Form { Text = Guid.NewGuid().ToString() }.Show(this);
			Controls.Add(newWindowBtn);
		}
	}
	static class NativeMethods
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct CWPSTRUCT
		{
			public IntPtr lparam;
			public IntPtr wparam;
			public int message;
			public IntPtr hwnd;
		}
		public delegate IntPtr CBTProc(int code, IntPtr wParam, IntPtr lParam);
		public enum HookType
		{
			WH_CALLWNDPROC = 4,
		}
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnhookWindowsHookEx(IntPtr hookPtr);
		[DllImport("kernel32.dll")]
		public static extern uint GetCurrentThreadId();
		[DllImport("user32.dll")]
		public static extern IntPtr CallNextHookEx(IntPtr hookPtr, int nCode, IntPtr wordParam, IntPtr longParam);
		[DllImport("user32.dll")]
		public static extern IntPtr SetWindowsHookEx(HookType hookType, CBTProc hookProc, IntPtr instancePtr, uint threadID);
	}
	static class Program
	{
		[STAThread]
		static void Main()
		{
			var hook = NativeMethods.SetWindowsHookEx(NativeMethods.HookType.WH_CALLWNDPROC, Callback, IntPtr.Zero, NativeMethods.GetCurrentThreadId());
			try
			{
				Application.Run(new Form1());
			}
			finally
			{
				NativeMethods.UnhookWindowsHookEx(hook);
			}
		}
		static IntPtr Callback(int code, IntPtr wParam, IntPtr lParam)
		{
			var msg = Marshal.PtrToStructure<NativeMethods.CWPSTRUCT>(lParam);
			if (msg.message == 0x0018)//WM_SHOWWINDOW
			{
				var form = Control.FromHandle(msg.hwnd) as Form;
				if (form != null)
				{
					Console.WriteLine($"Opened form [{form.Handle}|{form.Text}]");
				}
			}
			if (msg.message == 0x0010)//WM_CLOSE
			{
				var form = Control.FromHandle(msg.hwnd) as Form;
				if (form != null)
				{
					Console.WriteLine($"Closed form [{form.Handle}|{form.Text}]");
				}
			}
			return NativeMethods.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
		}
	}
}

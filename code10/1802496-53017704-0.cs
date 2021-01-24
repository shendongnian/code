    using NAudio.CoreAudioApi;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Enable_Device
    {
	class Program
	{
		[DllImport("User32.dll")]
		public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
		[DllImport("user32.dll", SetLastError = true)]
		static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
		private const UInt32 WM_CLOSE = 0x0010;
		static void CloseWindow(IntPtr hwnd)
		{
			SendMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
		}
		static void Main(string[] args)
		{
			string driverName = "Stereo Mix"; // any device name you want to enable
			MMDevice mMDevice;
			using (var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator())
			{
				mMDevice = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Disabled).ToList().Where(d => d.FriendlyName.ToLower().Contains(driverName.ToLower())).FirstOrDefault();
			}
			if (mMDevice != null)
			{
				driverName = mMDevice.FriendlyName;
				int charLocation = driverName.IndexOf("(", StringComparison.Ordinal);
				if (charLocation > 0)
				{
					driverName = driverName.Substring(0, charLocation);
					driverName = driverName.Trim();
				}
			}
			else
			{
				MessageBox.Show($"{driverName} Coudn't Found as Disabled Device.");
				return;
			}
			TryEnable(driverName, mMDevice);
		
		}
		private static void TryEnable(string driverName, MMDevice mMDevice)
		{
			try
			{
				var hwnd = 0;
				hwnd = FindWindow(null, "Sound");
				Process soundProc;
				if (hwnd == 0)
				{
					soundProc = Process.Start("control.exe", "mmsys.cpl,,1");
				}
				else
				{
					CloseWindow((IntPtr)hwnd);
					while (hwnd == 0)
					{
						Debug.WriteLine($"Waiting to Close ...");
						Task.Delay(1000);
						hwnd = FindWindow(null, "Sound");
					}
					soundProc = Process.Start("control.exe", "mmsys.cpl,,1");
				}
				hwnd = 0;
				hwnd = FindWindow(null, "Sound");
				while (hwnd == 0)
				{
					Debug.WriteLine($"Waiting ...");
					Task.Delay(1000);
					hwnd = FindWindow(null, "Sound");
				}
				if (hwnd == 0)
				{
					MessageBox.Show($"Couldnt find Sound Window.");
					return;
				}
				var id = GetWindowThreadProcessId((IntPtr)hwnd, out uint i);
				TestStack.White.Application application = TestStack.White.Application.Attach((int)i);
				Debug.WriteLine($"{application.Name}");
				TestStack.White.UIItems.WindowItems.Window window = application.GetWindow("Sound");
				var exists = window.Exists(TestStack.White.UIItems.Finders.SearchCriteria.ByText(driverName));
				if (exists)
				{
					TestStack.White.UIItems.ListBoxItems.ListItem listItem = window.Get<TestStack.White.UIItems.ListBoxItems.ListItem>(TestStack.White.UIItems.Finders.SearchCriteria.ByText(driverName));
					listItem.Focus();
					window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.UP);
					window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.DOWN);
					window.Keyboard.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.SHIFT);
					window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.F10);
					window.Keyboard.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.SHIFT);
					window.Keyboard.Enter("E");
				}
				else
				{
					window.Keyboard.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.SHIFT);
					window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.F10);
					window.Keyboard.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.SHIFT);
					window.Keyboard.Enter("S");
					window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
					TestStack.White.UIItems.ListBoxItems.ListItem listItem = window.Get<TestStack.White.UIItems.ListBoxItems.ListItem>(TestStack.White.UIItems.Finders.SearchCriteria.ByText(driverName));
					listItem.Focus();
					window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.UP);
					window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.DOWN);
					window.Keyboard.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.SHIFT);
					window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.F10);
					window.Keyboard.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.SHIFT);
					window.Keyboard.Enter("E");
				}
				if (mMDevice != null)
				{
					if (mMDevice.State == DeviceState.Active)
					{
						Debug.WriteLine($"{ mMDevice.FriendlyName}");
						CloseWindow((IntPtr)hwnd);
					}
					else
					{
						MessageBox.Show("Please Enable the device ");
					}
				}
			}
			catch (Exception)
			{
			}
		}
	 }
      }

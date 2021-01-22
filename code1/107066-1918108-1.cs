    namespace ConsoleApplication1 
    {
	class Program 
	{ 
		[DllImport("user32.dll")] 
		static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,UIntPtr dwExtraInfo);
		static void Main(string[] args)
		{            
			while (true)
			{
				keybd_event((byte)0x31, (byte)0x02, 0, UIntPtr.Zero);
				Thread.Sleep(3000);
				keybd_event((byte)0x31, (byte)0x82, (uint)0x2, UIntPtr.Zero);
				Thread.Sleep(1000);
			}
		}
	}
    }

	internal struct LASTINPUTINFO 
	{
		public uint cbSize;
		public uint dwTime;
	}
	/// <summary>
	/// Helps to find the idle time, (in milliseconds) spent since the last user input
	/// </summary>
	public class IdleTimeFinder
	{
		[DllImport("User32.dll")]
		private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);		
		[DllImport("Kernel32.dll")]
		private static extern uint GetLastError();
	
		public static uint GetIdleTime()
		{
			LASTINPUTINFO lastInPut = new LASTINPUTINFO();
			lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
			GetLastInputInfo(ref lastInPut);
			return ((uint)Environment.TickCount - lastInPut.dwTime);
		}
    /// <summary>
    /// Get the Last input time in milliseconds
    /// </summary>
    /// <returns></returns>
		public static long GetLastInputTime()
		{
			LASTINPUTINFO lastInPut = new LASTINPUTINFO();
			lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
			if (!GetLastInputInfo(ref lastInPut))
			{
				throw new Exception(GetLastError().ToString());
			}		
			return lastInPut.dwTime;
		}
	}

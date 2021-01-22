    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    //https://docs.microsoft.com/en-us/windows/desktop/api/lmremutl/nf-lmremutl-netremotetod
    public static class RemoteTOD {
    
    	// Important: CharSet must be Unicode otherwise error 2184 is returned
    	[DllImport("netapi32.dll", SetLastError=true, CharSet=CharSet.Unicode)]
    	private static extern int NetRemoteTOD(String UncServerName, ref IntPtr BufferPtr);
    
    	[DllImport("netapi32.dll")]
    	private static extern void NetApiBufferFree(IntPtr bufptr);
    
    	public static DateTime? GetNow(String serverName, bool throwException = false) {
    		IntPtr ptrBuffer = IntPtr.Zero;
    		int result = NetRemoteTOD(serverName, ref ptrBuffer);
    		if (result != 0) {
    			if (throwException)
    				throw new Win32Exception(Marshal.GetLastWin32Error());
    			return null;
    		}
    
    		TIME_OF_DAY_INFO tod = (TIME_OF_DAY_INFO) Marshal.PtrToStructure(ptrBuffer, typeof(TIME_OF_DAY_INFO));
    		NetApiBufferFree(ptrBuffer); // must be freed using NetApiBufferFree according to the documentation
    
    		//DateTime d0 = new DateTime(1970,1,1);
    		//d0 = d0.AddSeconds(tod.elapsedt);
    		DateTime nowUtc = new DateTime(tod.year, tod.month, tod.day, tod.hour, tod.minute, tod.second, 10 * tod.hunds);
    		DateTime now = nowUtc.ToLocalTime();
    		return now;
    	}
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct TIME_OF_DAY_INFO {
    
    	///<summary>The number of seconds since 00:00:00, January 1, 1970, GMT.</summary>
    	public int elapsedt;
    
    	///<summary>The number of milliseconds from an arbitrary starting point (system reset). Typically, this member is read twice,
    	///once when the process begins and again at the end. To determine the elapsed time between the process's start and finish,
    	///you can subtract the first value from the second.</summary>
    	public int msecs;
    
    	///<summary>The current hour. Valid values are 0 through 23.</summary>
    	public int hour;
    
    	///<summary>The current minute. Valid values are 0 through 59.</summary>
    	public int minute;
    
    	///<summary>The current second. Valid values are 0 through 59.</summary>
    	public int second;
    
    	///<summary>The current hundredth second (0.01 second). Valid values are 0 through 99.</summary>
    	public int hunds;
    
    	///<summary>The time zone of the server. This value is calculated, in minutes, from Greenwich Mean Time (GMT). For time zones
    	///west of Greenwich, the value is positive; for time zones east of Greenwich, the value is negative. A value of –1 indicates
    	///that the time zone is undefined.</summary>
    	public int timezone;
    
    	///<summary>The time interval for each tick of the clock. Each integral integer represents one ten-thousandth second (0.0001 second).</summary>
    	public int tinterval;
    
    	///<summary>The day of the month. Valid values are 1 through 31.</summary>
    	public int day;
    
    	///<summary>The month of the year. Valid values are 1 through 12.</summary>
    	public int month;
    
    	///<summary>The year.</summary>
    	public int year;
    
    	///<summary>The day of the week. Valid values are 0 through 6, where 0 is Sunday, 1 is Monday, and so on.</summary>
    	public int weekday;
    }

        public static DateTime Now()
		{
			GetSystemTimePreciseAsFileTime(out time);
			var newTime = (ulong)time.dwHighDateTime << (8 * 4) | time.dwLowDateTime;
			var newTimeSigned = Convert.ToInt64(newTime);
			return new DateTime(newTimeSigned).AddYears(1600).ToLocalTime();
		}
        static FileTime time;
		public struct FileTime
		{
			public uint dwLowDateTime;
			public uint dwHighDateTime;
		}
		[DllImport("Kernel32.dll")]
		public static extern void GetSystemTimePreciseAsFileTime(out FileTime lpSystemTimeAsFileTime);

	// 0.58 ms
	static string Method5(int millisecs)
	{
        // Fastest way to create a DateTime at midnight
        // Make sure you use the appropriate decimal separator
        return DateTime.FromBinary(599266080000000000).AddMilliseconds(millisecs).ToString("HH:mm:ss.fff");
	}
	// 0.59 ms
	static string Method4(int millisecs)
	{
        // Make sure you use the appropriate decimal separator
		return TimeSpan.FromMilliseconds(millisecs).ToString(@"hh\:mm\:ss\.fff");
	}
	// 0.93 ms
	static string Method6(int millisecs)
	{
		TimeSpan t = TimeSpan.FromMilliseconds(millisecs);
        // Make sure you use the appropriate decimal separator
		return string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
			t.Hours,
			t.Minutes,
			t.Seconds,
			t.Milliseconds);
	}

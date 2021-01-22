	[StructLayout(LayoutKind.Sequential, Size = MeasurementStructSize, Pack = 1)]
	struct MeasurementStruct
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 19)]
		public string Date;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
		public string SerialNumber;
	}

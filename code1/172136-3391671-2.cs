	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi, Pack=1)]
	public struct TCustomer
	{
		public Int32 CustomerNo;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
		public string FirstName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
		public string LastName;
	}

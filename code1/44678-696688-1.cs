	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct CARDIDTYPE {
		public UInt32 JobId;
		public UInt32 CardNum;
		public IntPtr hPrinter;
	}
	[StructLayout(LayoutKind.Sequential)]
	public class CARD_INFO_1 {
		public bool bActive;
		public bool bSuccess;
	}
	[StructLayout(LayoutKind.Sequential)]
	public class CARD_INFO_2 {
		public UInt32 dwCopiesPrinted;
		public UInt32 dwRemakeAttempts;
		public Win32Util.SYSTEMTIME TimeCompleted;
	}
	
	[DllImport("ICE_API.DLL", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
	public static extern bool GetCardId(HandleRef hDC, ref CARDIDTYPE pCardId);
	[DllImport(@"ICE_API.DLL", EntryPoint = "GetCardStatus", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
	public static extern bool GetCardStatus([MarshalAs(UnmanagedType.Struct)]CARDIDTYPE CardId, UInt32 level,
		[In, Out] CARD_INFO_1 pData, UInt32 cbBuf, out UInt32 pcbNeeded);
		
	[DllImport(@"ICE_API.DLL", EntryPoint = "GetCardStatus", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
	public static extern bool GetCardStatus([MarshalAs(UnmanagedType.Struct)]CARDIDTYPE CardId, UInt32 level,
		[In, Out] CARD_INFO_2 pData, UInt32 cbBuf, out UInt32 pcbNeeded);

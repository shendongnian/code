	internal class DLLWrapper
	{
		[DllImport(_libName, EntryPoint="DLLErrorMsg", CallingConvention=CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern UInt32 GetErrorMessage(UInt32 dwError, StringBuilder * pBuf, UInt32 nBufSize);
		
		public static UInt32 GetErrorMessage( UInt32 dwError, out string msg)
		{
			uint buffersize = 1024;
			StringBuilder sb = new StringBuilder((int)buffersize);
			uint result = GetErrorMessage( dwError, sb, buffersize );
			msg = sb.ToString();
			return result;
		}
	}

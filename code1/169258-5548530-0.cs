	[ComImport]
	[SuppressUnmanagedCodeSecurity]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("ca7e9ef0-1cbe-11d3-8d29-00a0c94bbfee")]
	public interface IAudioEncoderProperties
	{
		/// <summary>
		/// Is PES output enabled? Return TRUE or FALSE
		/// </summary>		
		int get_PESOutputEnabled([Out] out int dwEnabled);
		/// <summary>
		/// Enable/disable PES output
		/// </summary>		
		int set_PESOutputEnabled([In] int dwEnabled);
		/// <summary>
		/// Get target compression bitrate in Kbits/s
		/// </summary>		
		int get_Bitrate([Out] out int dwBitrate);
		/// <summary>
		/// Set target compression bitrate in Kbits/s
		/// Not all numbers available! See spec for details!
		/// </summary>		
		int set_Bitrate([In] int dwBitrate);
        ///... the rest of interface
    }

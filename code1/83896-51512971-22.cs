	/// <summary>
	/// 'Widen' each byte in 'bytes' to 16-bits with no consideration for
    /// character mapping or encoding
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe char[] WidenByteArray(byte[] bytes)
	{
		var rgch = new char[bytes.Length];
		if (rgch.Length > 0)
			fixed (char* dst = rgch)
			fixed (byte* src = bytes)
				widen_bytes_simd(dst, src, rgch.Length);
		return rgch;
	}

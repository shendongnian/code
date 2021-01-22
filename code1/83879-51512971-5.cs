	/// <summary>
	/// 'Widen' each byte in 'bytes' to 16-bits with no consideration for
    /// character mapping or encoding.
	/// </summary>
	public static unsafe String ByteArrayToString(byte[] bytes)
	{
		// note: possible zeroing penalty; consider buffer pooling or 
        // other ways to allocate target?
		var s = new String('\0', bytes.Length);
		if (s.Length > 0)
			fixed (char* dst = s)
			fixed (byte* src = bytes)
				widen_bytes_simd(dst, src, s.Length);
		return s;
	}

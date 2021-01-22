    /// <summary>
    /// Concatenate the strings in 'rg', none of which may be null, into a single String.
    /// </summary>
	public static unsafe String StringJoin(this String[] rg)
	{
		int i;
		if (rg == null || (i = rg.Length) == 0)
			return String.Empty;
		if (i == 1)
			return rg[0];
		String s, t;
		int cch = 0;
		do
			cch += rg[--i].Length;
		while (i > 0);
		if (cch == 0)
			return String.Empty;
		i = rg.Length;
		fixed (Char* _p = (s = new String(default(Char), cch)))
		{
			Char* pDst = _p + cch;
			do
				if ((t = rg[--i]).Length > 0)
					fixed (Char* pSrc = t)
						memcpy(pDst -= t.Length, pSrc, (UIntPtr)(t.Length << 1));
			while (pDst > _p);
		}
		return s;
	}
	[DllImport("MSVCR120_CLR0400", CallingConvention = CallingConvention.Cdecl)]
	static extern unsafe void* memcpy(void* dest, void* src, UIntPtr cb);

    /// <summary> Returns a String where the specified bytes are formatted in a
    /// 3-section debugger-style aligned memory display, 32-bytes per line </summary>
	public static unsafe String MemoryDisplay(byte[] mem, int i_start = 0, int c = -1)
	{
		if (mem == null)
			throw new ArgumentNullException();
		if (i_start < 0)
			throw new IndexOutOfRangeException();
		if (c == -1)
			c = mem.Length - i_start;
		else if (c < 0)
			throw new ArgumentException();
		if (c == 0)
			return String.Empty;
		char* pch = stackalloc Char[32];       // for building right side at the same time
		var sb = new StringBuilder((c / 32 + 1) * 140);            // exact pre-allocation
		c += i_start;
		for (int i = i_start & ~0x1F; i < c;)
		{
			sb.Append(i.ToString("x8"));
			sb.Append(' ');
			do
			{
				if (i < i_start || i >= c)          // non-requested area, or past the end
				{
					sb.Append("   ");   
					pch[i & 0x1F] = ' ';
				}
				else
				{
					var b = mem[i];
					sb.Append(b.ToString("x2") + " ");
					pch[i & 0x1F] = non_monospace(b) ? '.' : (Char)b;
				}
			}
			while ((++i & 0x1F) != 0);
			sb.Append(' ');
			sb.AppendLine(new String(pch, 0, 32));
		}
		return sb.ToString();
	}

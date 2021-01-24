	private static List<string> IntPtrToStringArrayAnsi(IntPtr ptr)
	{
		var lst = new List<string>();
		while (true)
		{
			var str = Marshal.PtrToStringAnsi(ptr);
			if (!string.IsNullOrEmpty(str))
			{
				lst.Add(str);
				ptr += str.Length + 1;
			}
			else
				break;
		}
		return lst.ToArray();
	}

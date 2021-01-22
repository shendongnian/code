	public static string GetSizeReadable(long i)
	{
		string sign = (i < 0 ? "-" : "");
		double readable = (i < 0 ? -i : i);
		string suffix;
		if (i >= 0x1000000000000000) // Exabyte
		{
			suffix = "EB";
			readable = (double)(i >> 50);
		}
		else if (i >= 0x4000000000000) // Petabyte
		{
			suffix = "PB";
			readable = (double)(i >> 40);
		}
		else if (i >= 0x10000000000) // Terabyte
		{
			suffix = "TB";
			readable = (double)(i >> 30);
		}
		else if (i >= 0x40000000) // Gigabyte
		{
			suffix = "GB";
			readable = (double)(i >> 20);
		}
		else if (i >= 0x100000) // Megabyte
		{
			suffix = "MB";
			readable = (double)(i >> 10);
		}
		else if (i >= 0x400) // Kilobyte
		{
			suffix = "KB";
			readable = (double)i;
		}
		else
		{
			return i.ToString("0 B"); // Byte
		}
		readable = readable / 1024;
		return sign + readable.ToString("0.### ") + suffix;
	}
    // EXAMPLE OUTPUT
    GetSizeReadable(1023); // 1023 B
    GetSizeReadable(1024); // 1 KB
    GetSizeReadable(1025); // 1.001 KB

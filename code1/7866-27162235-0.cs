		public static string FileSizeFormat(this long lSize)
		{
			double size = lSize;
			int index = 0;
			for(; size > 1024; index++)
				size /= 1024;
			return size.ToString("0.000 " + new[] { "B", "KB", "MB", "GB", "TB" }[index]);			
		}

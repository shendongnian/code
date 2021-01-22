	private void CombineFiles(string jpgFileName, string zipFileName)
	{
		using (Stream original = new FileStream(jpgFileName, FileMode.Append))
		{
			using (Stream extra = new FileStream(zipFileName, FileMode.Open, FileAccess.Read))
			{
				var buffer = new byte[32 * 1024];
				int blockSize;
				while ((blockSize = extra.Read(buffer, 0, buffer.Length)) > 0)
				{
					original.Write(buffer, 0, blockSize);
				}
			}
		}
	}

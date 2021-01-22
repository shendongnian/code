    public static void CopyStream(Stream input, Stream output, long length, DataInspector.ProgressCallback callback)
	{
		long totalsize = input.Length;
		long byteswritten = 0;
		const int size = 32768;
		byte[] buffer = new byte[size];
		int read;
		int readlen = length < size ? (int)length : size;
		while (length > 0 && (read = input.Read(buffer, 0, readlen)) > 0)
		{
			output.Write(buffer, 0, read);
			byteswritten += read;
			length -= read;
			readlen = length < size ? (int)length : size;
			if (callback != null)
				callback(byteswritten, totalsize);
		}
	}

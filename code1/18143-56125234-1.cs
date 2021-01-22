		public static long FindBinaryPattern(byte[] data, byte[] pattern)
		{
			using (MemoryStream stream = new MemoryStream(data))
			{
				return FindBinaryPattern(stream, pattern);
			}
		}
		public static long FindBinaryPattern(string filename, byte[] pattern)
		{
			using (FileStream stream = new FileStream(filename, FileMode.Open))
			{
				return FindBinaryPattern(stream, pattern);
			}
		}
		public static long FindBinaryPattern(Stream stream, byte[] pattern)
		{
			byte[] buffer = new byte[1024 * 1024];
			int patternIndex = 0;
			int read;
			while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
			{
				for (int bufferIndex = 0; bufferIndex < read; ++bufferIndex)
				{
					if (buffer[bufferIndex] == pattern[patternIndex])
					{
						++patternIndex;
						if (patternIndex == pattern.Length)
							return stream.Position - (read - bufferIndex) - pattern.Length + 1;
					}
					else
					{
						patternIndex = 0;
					}
				}
			}
			return -1;
		}
It does nothing cleaver, keeps it simple.

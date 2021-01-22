    private string ReadRows(int offset) 	/*offset: how many lines it reads from the end (10 in your case)*/
    {
		/*no lines to read*/
		if (offset == 0)
			return result;
		using (FileStream fs = new FileStream(FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 2048, true))
		{
			List<char> charBuilder = new List<char>(); /*StringBuilder doesn't work with Encoding: example char  */
			StringBuilder sb = new StringBuilder();
			int count = 0;
			/*tested with utf8 file encoded by notepad-pp; other encoding may not work*/
			
			var decoder = ReaderEncoding.GetDecoder();
			byte[] buffer;
			int bufferLength;
			fs.Seek(0, SeekOrigin.End);
			while (true)
			{
				bufferLength = 1;
				buffer = new byte[1];
				/*for encoding with variable byte size, every time I read a byte that is part of the character and not an entire character the decoder returns '�' (invalid character) */
				char[] chars = { '�' }; //� 65533
				int iteration = 0;
				while (chars.Contains('�'))
				{
					/*at every iteration that does not produce character, buffer get bigger, up to 4 byte*/
					if (iteration > 0)
					{
						bufferLength = buffer.Length + 1;
						byte[] newBuffer = new byte[bufferLength];
						Array.Copy(buffer, newBuffer, bufferLength - 1);
						buffer = newBuffer;
					}
					/*there are no characters with more than 4 bytes in utf-8*/
					if (iteration > 4)
						throw new Exception();
					
					/*if all is ok, the last seek return IOError with chars = empty*/
					try
					{
						fs.Seek(-(bufferLength), SeekOrigin.Current);
					}
					catch
					{
						chars = new char[] { '\0' };
						break;
					}
					fs.Read(buffer, 0, bufferLength);
					var charCount = decoder.GetCharCount(buffer, 0, bufferLength);
					chars = new char[charCount];
					decoder.GetChars(buffer, 0, bufferLength, chars, 0);
					++iteration;
				}
				/*when i get a char*/
				charBuilder.InsertRange(0, chars);
				if (chars.Length > 0 && chars[0] == '\n')
					++count;
			   
				/*exit when i get the correctly number of line (*last row is in interval)*/
				if (count == offset + 1)
					break;
				/*the first search goes back, the reading goes on then we come back again, except the last */
				try
				{
					fs.Seek(-(bufferLength), SeekOrigin.Current);
				}
				catch (Exception)
				{
					break;
				}
			}
		}
		
		/*everithing must be reversed, but not \0*/
		charBuilder.RemoveAt(0);
		/*yuppi!*/
		return new string(charBuilder.ToArray());
	}

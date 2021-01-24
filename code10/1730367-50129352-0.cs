	void Main()
	{
		string filename = @"C:\Temp\CHARGES.TXT";
		int start = 0;
		int end = 0;
	
		using (var fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
		{
			// get a big enough buffer to hold the whole file and read it in
			long fileSize = new FileInfo(filename).Length;
			var buffer = new byte[fileSize];
			var bytesRead = fs.Read(buffer, 0, buffer.Length);
	
			try
			{
				// convert each line to ASCII to process through to API
				while (end < bytesRead)
				{
					while (end < bytesRead && buffer[end] != 0x0A && buffer[end] != 0x0D)
					{
						end++;
					}
					var text = ASCIIEncoding.ASCII.GetString(buffer, start, end - start);
	
					// Send to API
					Console.WriteLine("Start [{0}] End [{1}] Text [{2}]", start, end, text);
	
					if (end < bytesRead)
					{
						end += 2;
						start = end;
					}
					if (end > bytesRead / 2)
					{
						throw new NotImplementedException();
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("just to prove the partial");
			}		
			finally
			{
				// convert any remaining records back to bytes and write back to file
				fs.SetLength(0);
				fs.Write(buffer, end, bytesRead - end);
			}
		}
	}
	

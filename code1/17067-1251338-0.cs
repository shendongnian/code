    public static class Extensions
    {
    	/// <summary>
    	/// Converts a byte array to a string, using its byte order mark to convert it to the right encoding.
    	/// Original article: http://www.west-wind.com/WebLog/posts/197245.aspx
    	/// </summary>
    	/// <param name="buffer">An array of bytes to convert</param>
    	/// <returns>The byte as a string.</returns>
    	public static string GetString(this byte[] buffer)
    	{
    		if (buffer == null || buffer.Length == 0)
    			return "";
    
    		// Ansi as default
    		Encoding encoding = Encoding.Default;		
    
    		/*
    			EF BB BF	UTF-8 
    			FF FE UTF-16	little endian 
    			FE FF UTF-16	big endian 
    			FF FE 00 00	UTF-32, little endian 
    			00 00 FE FF	UTF-32, big-endian 
    		 */
    
    		if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
    			encoding = Encoding.UTF8;
    		else if (buffer[0] == 0xfe && buffer[1] == 0xff)
    			encoding = Encoding.Unicode;
    		else if (buffer[0] == 0xfe && buffer[1] == 0xff)
    			encoding = Encoding.BigEndianUnicode; // utf-16be
    		else if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xfe && buffer[3] == 0xff)
    			encoding = Encoding.UTF32;
    		else if (buffer[0] == 0x2b && buffer[1] == 0x2f && buffer[2] == 0x76)
    			encoding = Encoding.UTF7;
    
    		using (MemoryStream stream = new MemoryStream())
    		{
    			stream.Write(buffer, 0, buffer.Length);
    			stream.Seek(0, SeekOrigin.Begin);
    			using (StreamReader reader = new StreamReader(stream, encoding))
    			{
    				return reader.ReadToEnd();
    			}
    		}
    	}
    }

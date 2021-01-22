    public static class RandomEx
    {
    	/// <summary>
    	/// Generates random string of printable ASCII symbols of a given length
    	/// </summary>
    	/// <param name="r">instance of the Random class</param>
    	/// <param name="length">length of a random string</param>
    	/// <returns>Random string of a given length</returns>
    	public static string NextString(this Random r, int length)
    	{
    		var data = new byte[length];
    		for (int i = 0; i < data.Length; i++)
    		{
    			// All ASCII symbols: printable and non-printable
    			// data[i] = (byte)r.Next(0, 128);
    			// Only printable ASCII
    			data[i] = (byte)r.Next(32, 127);
    		}
    		var encoding = new ASCIIEncoding();
    		return encoding.GetString(data);
    	}
    
    	/// <summary>
    	/// Generates random string of printable ASCII symbols
    	/// with random length of 10 to 20 chars
    	/// </summary>
    	/// <param name="r">instance of the Random class</param>
    	/// <returns>Random string of a given length</returns>
    	public static string NextString(this Random r)
    	{
    		int length  = r.Next(10, 21);
    		return NextString(r, length);
    	}
    }

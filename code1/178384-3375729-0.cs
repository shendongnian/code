    void Main()
    {
    	string sqlDate = "2010-07-23T17:14:40-04:00";
    	
    	DateTime dt = DateTime.Parse(sqlDate);
    	
    	Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));
    }

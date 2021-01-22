    public static bool IsDateTime(string txtDate)
    {
    	DateTime tempDate;
    
    	return DateTime.TryParse(txtDate, out tempDate) ? true : false;
    }

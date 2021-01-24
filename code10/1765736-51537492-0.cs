    public DateTime ExtractDateTime(string log)
    {
        string pattern = @"\d{4}.\d{2}.\d{2} \d{2}.\d{2}.\d{2}.\d{4}";
        var match = Regex.Match(log, pattern);
    	DateTime parsedDate;
    	if(DateTime.TryParseExact(match.Value, "yyyy.MM.dd hh:mm:ss:ffff",System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None, out parsedDate))
    	{
    		return parsedDate;
    	}
        return new DateTime();
    }
    
    public string WhenCreateLog(string log, int year, int month, int day, int hour, int minute, int second, int millisecond, out DateTime actualDate)
    {
    	actualDate = new DateTime(year, month, day, hour, minute, second, millisecond);
        var request = $"{actualDate.ToString("yyyy.MM.dd HH:mm:ss:ffff")}: {log}";
        //Or
    	//var request = $"{year}.{month.ToString().PadLeft(2, '0')}.{day.ToString().PadLeft(2, '0')} {hour.ToString().PadLeft(2, '0')}:{minute.ToString().PadLeft(2, '0')}:{second.ToString().PadLeft(2, '0')}:{millisecond.ToString().PadRight(4, '0')}";
    	return request;
    }

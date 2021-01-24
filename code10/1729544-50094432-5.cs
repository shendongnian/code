    public static DateTime ToDateTime(this string myString)
    	{
    		
    		var regex = new Regex(@"\d\d \/ \d\d \/ \d\d\d\d");
    		var match = regex.Match(myString);
    		
    		var date = DateTime.ParseExact(match.ToString().Replace(" ", ""), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    		return date;
    	}

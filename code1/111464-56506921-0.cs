    string input="07/06/2019 07:01:54 p. m.";
       
		
    public static DateTime ParseSpanishDate(string input)
    {
        string normalized = input.Replace("a. m.", "AM").Replace("p. m.", "PM");
        normalized = normalized.Replace("12:00:00 AM", "00:00:00 AM");
        return  DateTime.Parse(normalized, CultureInfo.GetCultureInfo("es"));
    }

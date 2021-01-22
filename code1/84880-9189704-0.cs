	void Main()
	{
        List<string> inputs = new List<string>() {     
            "1.234.567,89",     
            "1 234 567,89",     
            "1 234 567.89",     
            "1,234,567.89",    
            "1234567,89",     
            "1234567.89",  
            "123456789",   
            "123.456.789", 
            "123,456,789,"
        }; 
        foreach(string input in inputs) {
            Console.WriteLine(GetDouble(input,0d));
        }
		
	}
    public static double GetDouble(string value, double defaultValue) {
        double result;
        string output;
        // check if last seperator==groupSeperator
        string groupSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
        if (value.LastIndexOf(groupSep) + 4 == value.Count())
        {
            bool tryParse = double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            result = tryParse ? result : defaultValue;
        } 
        else 
        {
            // unify string (no spaces, only . )     
            output = value.Trim().Replace(" ", string.Empty).Replace(",", ".");      
            split it on points     
            string[] split = output.Split('.');      
            if (split.Count() > 1)     
            {         
                // take all parts except last         
                output = string.Join(string.Empty, split.Take(split.Count()-1).ToArray()); 
         
                // combine token parts with last part         
                output = string.Format("{0}.{1}", output, split.Last());     
            }      
            // parse double invariant     
            result = double.Parse(output, System.Globalization.CultureInfo.InvariantCulture); 
            }
        }
        return result;
    }

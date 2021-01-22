    StringBuilder sb = new StringBuilder (value.Length);
    foreach (char c in value)
    {
    	if (char.IsNumber(c)|c == System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator )
    		sb.Append (c);
    }
    string value= sb.ToString();

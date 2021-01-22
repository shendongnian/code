    StringBuilder sb = new StringBuilder (value.Length);
    foreach (char c in value)
    {
    	if (!char.IsWhiteSpace (c))
    		sb.Append (c);
    }
    string value= sb.ToString();

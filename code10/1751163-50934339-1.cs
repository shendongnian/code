    private static string CleanUpText(string text)
    {
    	var formD = text.Normalize(NormalizationForm.FormD);
    	var sb = new StringBuilder();
    
    	foreach (var ch in formD)
    	{
    		var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
    
    		if (uc != UnicodeCategory.NonSpacingMark)
    		{
    			sb.Append(ch);
    		}
    	}
    
    	return sb.ToString().Normalize(NormalizationForm.FormC).ToLower();
    }

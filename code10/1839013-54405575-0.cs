    public static class StringExtension
    {
    	public static bool IsUnicodeCharacterInIt(this string value)
    	{
    		return value.Any(c => c > 255);
    	}
    }
    public void Check()
    {
    	var unicodeString = "سلام بیبی";
    	var nonUnicodeString = "hi baby";
    
    	var result1 = unicodeString.IsUnicodeCharacterInIt();
    	var result2 = nonUnicodeString.IsUnicodeCharacterInIt();
    }

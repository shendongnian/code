    public int Get4LetterYear(int twoLetterYear)
    {
    	int firstTwoDigits =
            Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2));
    	return Get4LetterYear(twoLetterYear, firstTwoDigits);
    }
    
    public int Get4LetterYear(int twoLetterYear, int firstTwoDigits)
    {
    	return Convert.ToInt32(firstTwoDigits.ToString() + twoLetterYear.ToString());
    }
    
    public int Get2LetterYear(int fourLetterYear)
    {
    	return Convert.ToInt32(fourLetterYear.ToString().Substring(2, 2));
    }

    static char[] signChars = new char[] { '+', '-' };
    static float ParseFloatingPoint(string data)
    {
    	if (data.Length != EntryWidth)
    	{
    	    throw new ArgumentException("data is not the correct size", "data");
    	}
    	else if (data[0] != ' ' && data[0] != '+' && data[0] != '-')
    	{
    		throw new ArgumentException("unexpected leading character", "data");
    	}
    
        int signPos = data.LastIndexOfAny(signChars);
        // Found either a '+' or '-'
        if (signPos > 0)
        {
            // Create a new char array with an extra space to accomodate the 'e'
            char[] newData = new char[EntryWidth + 1];
            // Copy from string up to the sign
            for (int ii = 0; ii < signPos; ++ii)
            {
                newData[ii] = data[ii];
            }
            // Replace the sign with an 'e + sign'
            newData[signPos] = 'e';
            newData[signPos + 1] = data[signPos];
            // Copy the rest of the string
            for (int ii = signPos + 2; ii < EntryWidth + 1; ++ii)
            {
                newData[ii] = data[ii - 1];
            }
            return Single.Parse(
                new string(newData),
                NumberStyles.Float,
                CultureInfo.InvariantCulture);
        }
        else
        {
            Debug.Assert(false, "data does not have an exponential? This is odd.");
            return Single.Parse(data, NumberStyles.Float, CultureInfo.InvariantCulture);
        }
    }

    // IsNumeric Function
    static bool IsNumeric(object Expression)
    {
        // Variable to collect the Return value of the TryParse method.
    	bool isNum;
    
        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
    	double retNum;
    			
        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
    	isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum );
    	return isNum;
    }

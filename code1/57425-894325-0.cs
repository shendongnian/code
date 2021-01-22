    public static bool IsNumeric(object Expression)
    	{
    		bool isNum;
    		double retNum;
    		
    		isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo, out retNum );
    		return isNum;
    	}

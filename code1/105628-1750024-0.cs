    public static bool IsNumeric(object expression)
    {
       if (expression == null)
       return false;
    
       double number;
       return Double.TryParse(Convert.ToString(expression, CultureInfo.InvariantCulture), System.Globalization.NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
    }

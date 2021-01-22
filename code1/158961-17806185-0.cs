    using System;
    using System.Globalization;
     
    namespace ConvertSpacesToUnderscores
    {
       public static class NumberFunctions
       {
          public static bool IsNumeric(this object expression)
          {
             if (expression == null)
    	     {
    	        return false;
    	     }
    	     double number;
             return Double.TryParse(Convert.ToString(expression, CultureInfo.InvariantCulture), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
          }
       }
    }

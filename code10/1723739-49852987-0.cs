    string target = "-0.0";  
    decimal result= (decimal.Parse(target,
                     System.Globalization.NumberStyles.AllowParentheses |
                     System.Globalization.NumberStyles.AllowLeadingWhite |
                     System.Globalization.NumberStyles.AllowTrailingWhite |
                     System.Globalization.NumberStyles.AllowThousands |
                     System.Globalization.NumberStyles.AllowDecimalPoint |
                     System.Globalization.NumberStyles.AllowLeadingSign));

     using System.Text.RegularExpressions;
     ...
     string strExpression  = "hey! Hello World. SpecialDayForMe";
     string toFind = "SpecialDay";
     strExpression = Regex.Replace(
       strExpression, 
      @"\b" + Regex.Escape(toFind) + @"\b", // Regex.Escape to be on the safe side
       "ABC");

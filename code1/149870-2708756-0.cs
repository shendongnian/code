    using System.Text.RegularExpressions;
    
    int GetNumberFromString( string str_age )
    {
         Regex number = new Regex("[0-9][0-9]?");
         Match n = number.Match(str_age);
         if (n.Value != "")
             return System.Convert.ToInt16(n.Value, 10);
         else
             return -1;            
    }

    using System.Text.RegularExpressions;
    
    //-----------------------------------------------------------------
    
    string str = Regex.Replace("MyString", @"([A-Z])", " $1").Trim();
    
    //-----------------------------------------------------------------
    
    str givs "My String"

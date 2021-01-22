    public static string CleanInvalidXmlChars(string text)   
    {   
           string re = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";   
           return Regex.Replace(text, re, "");   
    } 

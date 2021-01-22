    public static class StringHelpers 
    { 
        public static string GetLabelFromLine(this string line) 
        { 
             int separatorIndex = line.IndexOf(':');
             if (separatorIndex > 0)
             {
                string possibleLabel = line.Substring(0, separatorIndex).Trim();
                if(possibleLabel.IndexOf(' ') < 0) 
                {
                    return possibleLabel;
                }
             }
             else
             {
                return string.Empty;
             }        
         } 
 
        public static string StripLabelFromLine(this string line) 
        { 
            int separatorIndex = line.IndexOf(':');
             if (separatorIndex > 0)
             {
                return line.Substring(separatorIndex + 1, 
                       line.Length - separatorIndex - 1).Trim();
             }
             else
             {
                return line;
             }      
        } 
 
        public static bool IsNullOrEmpty(this string line) 
        { 
            return String.IsNullOrEmpty(line); 
        } 
    } 

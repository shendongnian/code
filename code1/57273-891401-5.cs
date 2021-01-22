    public class XmlExpresssion
    {
        // EXPLANATION OF EXPRESSION
        // <        :   \<{1}
        // text     :   (?<xmlTag>\w+)  : xmlTag is a backreference so that the start and end tags match
        // >        :   >{1}
        // xml data :   (?<data>.*)     : data is a backreference used for the regex to return the element data      
        // </       :   <{1}/{1}
        // text     :   \k<xmlTag>
        // >        :   >{1}
        // (\w|\W)* :   Matches attributes if any
    
        // Sample match and pattern egs
        // Just to show how I incrementally made the patterns so that the final pattern is well-understood
        // <text>data</text>
        // @"^\<{1}(?<xmlTag>\w+)\>{1}.*\<{1}/{1}\k<xmlTag>\>{1}$";
    
        //<text />
        // @"^\<{1}(?<xmlTag>\w+)\s*/{1}\>{1}$";
    
        //<text>data</text> or <text />
        // @"^\<{1}(?<xmlTag>\w+)((\>{1}.*\<{1}/{1}\k<xmlTag>)|(\s*/{1}))\>{1}$";
    
        //<text>data</text> or <text /> or <text attr='2'>xml data</text> or <text attr='2' attr2 >data</text>
        // @"^\<{1}(?<xmlTag>\w+)(((\w|\W)*\>{1}(?<data>.*)\<{1}/{1}\k<xmlTag>)|(\s*/{1}))\>{1}$";
    
        private const string XML_PATTERN = @"^\<{1}(?<xmlTag>\w+)(((\w|\W)*\>{1}(?<data>.*)\<{1}/{1}\k<xmlTag>)|(\s*/{1}))\>{1}$";
    
        // Checks if the string is in xml format
        private static bool IsXml(string value)
        {
            return Regex.IsMatch(value, XML_PATTERN);
        }
    
        /// <summary>
        /// Assigns the element value to result if the string is xml
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public static bool TryParse(string s, out string result)
        {
            if (XmlExpresssion.IsXml(s))
            {
                Regex r = new Regex(XML_PATTERN, RegexOptions.Compiled);
                result = r.Match(s).Result("${data}");
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
      
    }

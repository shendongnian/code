    static string RemoveCstyleComments(string strInput)
    {
        string strPattern = @"/[*][\w\d\s]+[*]/";
        //strPattern = @"/\*.*?\*/"; // Doesn't work
        //strPattern = "/\\*.*?\\*/"; // Doesn't work
        //strPattern = @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/ "; // Doesn't work
        //strPattern = @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/ "; // Doesn't work
        // http://stackoverflow.com/questions/462843/improving-fixing-a-regex-for-c-style-block-comments
        strPattern = @"/\*(?>(?:(?>[^*]+)|\*(?!/))*)\*/";  // Works !
        string strOutput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, string.Empty, System.Text.RegularExpressions.RegexOptions.Multiline);
        Console.WriteLine(strOutput);
        return strOutput;
    } // End Function RemoveCstyleComments

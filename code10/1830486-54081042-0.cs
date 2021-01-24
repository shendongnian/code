    static String SeparateBy(
        this string str, 
        string separator, 
        int groupLength)
    {
        var buffer = new StringBuilder();
        
        for (var i = 0; i < str.Length; i++)
        {
            if (i % groupLength == 0)
            {
                buffer.Append(separator);
            }
            
            buffer.Append(str[i]);
        }
        
        return buffer.ToString();
    }

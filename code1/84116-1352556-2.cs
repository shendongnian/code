    /// <summary>
    /// Produce an XPath literal equal to the value if possible; if not, produce
    /// an XPath expression that will match the value.
    /// 
    /// Note that this function will produce very long XPath expressions if a value
    /// contains a long run of double quotes.
    /// </summary>
    /// <param name="value">The value to match.</param>
    /// <returns>If the value contains only single or double quotes, an XPath
    /// literal equal to the value.  If it contains both, an XPath expression,
    /// using concat(), that evaluates to the value.</returns>
    static string XPathLiteral(string value)
    {
        // if the value contains only single or double quotes, construct
        // an XPath literal
        if (!value.Contains("\""))
        {
            return "\"" + value + "\"";
        }
        if (!value.Contains("'"))
        {
            return "'" + value + "'";
        }
        // if the value contains both single and double quotes, construct an
        // expression that concatenates all non-double-quote substrings with
        // the quotes, e.g.:
        //
        //    concat("foo", '"', "bar")
        StringBuilder sb = new StringBuilder();
        sb.Append("concat(");
        string[] substrings = value.Split('\"');
        for (int i = 0; i < substrings.Length; i++ )
        {
            bool needComma = (i>0);
            if (substrings[i] != "")
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append("\"");
                sb.Append(substrings[i]);
                sb.Append("\"");
                needComma = true;
            }
            if (i < substrings.Length - 1)
            {
                if (needComma)
                {
                    sb.Append(", ");                    
                }
                sb.Append("'\"'");
            }
            
        }
        sb.Append(")");
        return sb.ToString();
    }

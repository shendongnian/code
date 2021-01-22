    //string EncodedXml = SpecialXmlEscape("привет мир");
    //Console.WriteLine(EncodedXml);
    //string DecodedXml = XmlUnescape(EncodedXml);
    //Console.WriteLine(DecodedXml);
    public static string SpecialXmlEscape(string input)
    {
        //string content = System.Xml.XmlConvert.EncodeName("\t");
        //string content = System.Security.SecurityElement.Escape("\t");
        //string strDelimiter = System.Web.HttpUtility.HtmlEncode("\t"); // XmlEscape("\t"); //XmlDecode("&#09;");
        //strDelimiter = XmlUnescape("&#59;");
        //Console.WriteLine(strDelimiter);
        //Console.WriteLine(string.Format("&#{0};", (int)';'));
        //Console.WriteLine(System.Text.Encoding.ASCII.HeaderName);
        //Console.WriteLine(System.Text.Encoding.UTF8.HeaderName);
        
        string strXmlText = "";
        if (string.IsNullOrEmpty(input))
            return input;
        System.Text.StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; ++i)
        {
            sb.AppendFormat("&#{0};", (int)input[i]);
        }
        strXmlText = sb.ToString();
        sb.Clear();
        sb = null;
        return strXmlText;
    } // End Function SpecialXmlEscape

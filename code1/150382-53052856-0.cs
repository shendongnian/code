    public static string RecursiveHtmlDecode(string str) {
        if (string.IsNullOrWhiteSpace(str)) return str;  
        var tmp = HttpUtility.HtmlDecode(str);
        while (tmp != str)
        {
            str = tmp;
            tmp = HttpUtility.HtmlDecode(str);
        }
        return str; //completely decoded string
    }

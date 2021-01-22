    using System.Web;
    public static string ExtractText(string html)
	{
       	Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
       	string s =reg.Replace(html, " ");
       	s = HttpUtility.HtmlDecode(s);
       	return s;
    }

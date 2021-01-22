    public static string StripHtml(String htmlText)
    {
        // replace all tags with spaces...
       htmlText = Regex.Replace(htmlText, @"<(.|\n)*?>", " ");
   
       // .. then eliminate all double spaces
       while (htmlText.Contains("  "))
       {
           htmlText = htmlText.Replace("  ", " ");
        }
       // clear out non-breaking spaces and & character code
       htmlText = htmlText.Replace("&nbsp;", " ");
       htmlText = htmlText.Replace("&amp;", "&");
       return htmlText;
    }

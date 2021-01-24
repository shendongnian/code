    void Convert(IEnumerable<string> content)
    {
        var htmls = content.Select(ConvertToHtml);
    
        HtmlDocument ConvertToHtml(string c)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(c);
            return doc;
        }
    }

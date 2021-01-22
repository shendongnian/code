    public List<Uri> FetchLinksFromSource(string htmlSource)
    {
        List<Uri> links = new List<Uri>();
        string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
        MatchCollection matchesImgSrc = Regex.Matches(source, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        foreach (Match m in matchesImgSrc)
        {
            string href = m.Groups[1].Value;
            links.Add(new Uri(href));
        }
        return links;
    }

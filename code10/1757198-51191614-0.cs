    var html = "<p class=\"b-list__count__number\">\n<span>61</span>/\n<span>18786</span>\n</p>";
    HtmlAgilityPack.HtmlDocument hap;
    Uri uriResult;
    if (Uri.TryCreate(html, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
    { // html is a URL 
        var doc = new HtmlAgilityPack.HtmlWeb();
        hap = doc.Load(uriResult.AbsoluteUri);
    }
    else
    { // html is a string
        hap = new HtmlAgilityPack.HtmlDocument();
        hap.LoadHtml(html);
    }
    var node = hap.DocumentNode.SelectSingleNode("//p[@class='b-list__count__number']");
    if (node != null)
    {
        Console.Write(node.SelectSingleNode("//span").InnerText); // => 61
    }

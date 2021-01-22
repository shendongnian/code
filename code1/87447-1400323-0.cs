    protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (HttpContext.Current.Request.Url.Scheme == "https")
            {
                StringBuilder stringBuilder = new StringBuilder();
                HtmlTextWriter pageTextWriter = new HtmlTextWriter(new StringWriter(stringBuilder, System.Globalization.CultureInfo.InvariantCulture));
                base.Render(pageTextWriter);
                string strContents = stringBuilder.ToString();
                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPackHtmlDocument();
                htmldoc.LoadHtml(stringBuilder.ToString());
                HtmlAgilityPack.HtmlNodeCollection linkNodes = htmldoc.DocumentNode.SelectNodes("//a[@href]");
                if (linkNodes != null)
                {
                    Uri baseUri = new Uri("http://www.mynonsslwebroot.co.uk/");
                    foreach (HtmlAgilityPack.HtmlNode node in linkNodes)
                    {
                        Uri uri;
                        if (Uri.TryCreate(baseUri, node.Attributes["href"].Value, out uri))
                        {
                            node.Attributes["href"].Value = uri.OriginalString;
                        }
                    }
                    writer.Write(htmldoc.DocumentNode.WriteTo());
                }
            }
     else
            {
                base.Render(writer);
            }
        }

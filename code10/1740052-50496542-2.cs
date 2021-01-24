    public static string RemoveAllAttributesFromEveryNode(string html)
        {
            try
            {
                HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                if (document.DocumentNode.InnerHtml.Contains("<img"))
                {
                    foreach (var eachNode in document.DocumentNode.SelectNodes("//img"))
                    {
                        eachNode.Remove();
                    }
                }
                html = document.DocumentNode.OuterHtml;
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

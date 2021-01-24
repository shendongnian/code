    public static string RemoveAllImageNodes(string html)
        {
            try
            {
                HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                var nodes = document.DocumentNode.SelectNodes("//img");
                foreach (var node in nodes)
                {
                    node.Remove();
                }
                html = document.DocumentNode.OuterHtml;
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
                    //node.Attributes.Remove("src"); //This only removes the src Attribute from <img> tag
                }
                html = document.DocumentNode.OuterHtml;
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     public static class HtmlTextEncoder
     {
        public static string HtmlEncode(string html)
        {
            if (html == null) return null;
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            EncodeNode(doc.DocumentNode);
            doc.OptionWriteEmptyNodes = true;
            using (var s = new MemoryStream())
            {
                doc.Save(s);
                var encoded = doc.Encoding.GetString(s.ToArray());
                return encoded;
            }
        }
        private static void EncodeNode(HtmlNode node)
        {
            if (node.HasChildNodes)
            {
                foreach (var childNode in node.ChildNodes)
                {
                    if (childNode.NodeType == HtmlNodeType.Text)
                    {
                        childNode.InnerHtml = HttpUtility.HtmlEncode(childNode.InnerHtml);
                    }
                    else
                    {
                        EncodeNode(childNode);
                    }
                }
            }
            else if (node.NodeType == HtmlNodeType.Text)
            {
                node.InnerHtml = HttpUtility.HtmlEncode(node.InnerHtml);
            }
        }
    }

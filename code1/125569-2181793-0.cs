      public static HtmlNode GetNodeByInnerText(string sHTML, string sText)
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(sHTML);
                int Position = sHTML.ToString().IndexOf(sText);
                return FindNodeByPosition(doc.DocumentNode, Position);
            }
        private static HtmlNode FindNodeByPosition(HtmlNode node, int Position)
        {
            HtmlNode foundNode = null;
            foreach (HtmlNode child in node.ChildNodes)
            {
                if (child.StreamPosition <= Position & ((child.NextSibling == null) || child.NextSibling.StreamPosition > Position))
                {
                    if (child.ChildNodes.Count > 0 & !(child.ChildNodes.Count == 1 && child.InnerHtml == child.FirstChild.InnerHtml))
                    {
                        foundNode = FindNodeByPosition(child, Position);
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    else
                    {
                        return child;
                    }
                }
            }
            return foundNode;
        }

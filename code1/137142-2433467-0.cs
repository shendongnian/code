    public static class HtmlParser
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static HtmlDocument _htmlDocument;
        public static string Parse(string input)
        {
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(input);
            ParseNode(_htmlDocument.DocumentNode);
            return _htmlDocument.DocumentNode.WriteTo().Trim();
        }
        private static void ParseChildren(HtmlNode parentNode)
        {
            for (int i = parentNode.ChildNodes.Count - 1; i >= 0; i--)
            {
                ParseNode(parentNode.ChildNodes[i]);
            }
        }
        private static void ParseNode(HtmlNode node)
        {
            if (node.NodeType == HtmlNodeType.Element)
            {
                if (node.Name == "img" && node.HasAttributes)
                {
                    for (int i = node.Attributes.Count - 1; i >= 0; i--)
                    {
                        HtmlAttribute currentAttribute = node.Attributes[i];
                        if ("class" == currentAttribute.Name && currentAttribute.Value.ToLower().Contains("featured"))
                        {
                            try
                            {
                                string originaleImagePath = node.Attributes["src"].Value;
                                string imageThumbnailPath = GetImageThumbnail(originaleImagePath);
                                var anchorNode = HtmlNode.CreateNode("<a>");
                                var imageNode = HtmlNode.CreateNode("<img>");
                                imageNode.SetAttributeValue("alt", node.Attributes["alt"].Value);
                                imageNode.SetAttributeValue("src", imageThumbnailPath);
                                anchorNode.SetAttributeValue("href", originaleImagePath);
                                anchorNode.AppendChild(imageNode);
                                node.ParentNode.InsertBefore(anchorNode, node);
                                node.ParentNode.RemoveChild(node);
                            }
                            catch (Exception exception)
                            {
                                if (_log.IsDebugEnabled)
                                {
                                    _log.WarnFormat("Some message: {0}", exception);
                                }
                            }
                        }
                    }
                }
            }
            if (node.HasChildNodes)
            {
                ParseChildren(node);
            }
        }
    }
}

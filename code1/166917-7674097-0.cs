    class TagSanitizer
    {
        List<HtmlNode> _deleteNodes = new List<HtmlNode>();
        public static void Sanitize(HtmlNode node)
        {
            new TagSanitizer().Clean(node);
        }
        void Clean(HtmlNode node)
        {
            CleanRecursive(node);
            for (int i = _deleteNodes.Count - 1; i >= 0; i--)
            {
                HtmlNode nodeToDelete = _deleteNodes[i];
                nodeToDelete.ParentNode.RemoveChild(nodeToDelete, true);
            }
        }
        void CleanRecursive(HtmlNode node)
        {
            if (node.NodeType == HtmlNodeType.Element)
            {
                if (Config.TagsWhiteList.ContainsKey(node.Name) == false)
                {
                    _deleteNodes.Add(node);
                }
                else if (node.HasAttributes)
                {
                    for (int i = node.Attributes.Count - 1; i >= 0; i--)
                    {
                        HtmlAttribute currentAttribute = node.Attributes[i];
                        string[] allowedAttributes = Config.TagsWhiteList[node.Name];
                        if (allowedAttributes != null)
                        {
                            if (allowedAttributes.Contains(currentAttribute.Name) == false)
                            {
                                node.Attributes.Remove(currentAttribute);
                            }
                        }
                        else
                        {
                            node.Attributes.Remove(currentAttribute);
                        }
                    }
                }
            }
            if (node.HasChildNodes)
            {
                node.ChildNodes.ToList().ForEach(v => CleanRecursive(v));
            }
        }
    }

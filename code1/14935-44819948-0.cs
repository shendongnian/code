     public static string GetFullPath(this XmlNode node)
            {
                if (node.ParentNode == null)
                {
                    return "";
                }
                else
                {
                    return $"{GetFullPath(node.ParentNode)}\\{node.ParentNode.Name}";
                }
            }

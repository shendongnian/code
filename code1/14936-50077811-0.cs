        private string GetPath(XmlElement el)
        {
            List<string> pathList = new List<string>();
            XmlNode node = el;
            while (node is XmlElement)
            {
                pathList.Add(node.Name);
                node = node.ParentNode;
            }
            pathList.Reverse();
            string[] nodeNames = pathList.ToArray();
            return String.Join("/", nodeNames);
        }

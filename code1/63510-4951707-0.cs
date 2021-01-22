        static XElement stripNS(XElement root)
        {
            XElement res = new XElement(
                root.Name.LocalName,
                root.HasElements ?
                    root.Elements().Select(el => stripNS(el)) :
                    (object)root.Value
            );
            res.ReplaceAttributes(
                root.Attributes().Where(attr => (!attr.IsNamespaceDeclaration)));
            return res;
        }

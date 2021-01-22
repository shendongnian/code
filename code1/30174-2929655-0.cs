        private static void ApplyNamespace(XElement parent, XNamespace nameSpace)
        {
            if(DetermineIfNameSpaceShouldBeApplied(parent, nameSpace))
            {
                parent.Name = nameSpace + parent.Name.LocalName;
            }
            foreach (XElement child in parent.Elements())
            {
                ApplyNamespace(child, nameSpace);
            }
        }

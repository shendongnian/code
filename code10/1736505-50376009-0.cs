    public static void RemoveNamespace(this XElement element)
    {
        element.Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
        element.Name = element.Name.LocalName;
    }

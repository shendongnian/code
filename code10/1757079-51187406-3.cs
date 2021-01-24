    public static void RemoveNamespace(this XContainer pContainer)
    {
        pContainer.Descendants().Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
    
        foreach (var element in pContainer.Descendants())
            element.Name = element.Name.LocalName;
    }

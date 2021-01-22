    /// <summary>
    /// Returns the specified <see cref="XElement"/>
    /// without namespace qualifiers on elements and attributes.
    /// </summary>
    /// <param name="element">The element</param>
    public static XElement WithoutNamespaces(this XElement element)
    {
        if (element == null) return null;
        #region delegates:
            Func<XNode, XNode> getChildNode = e => (e.NodeType == XmlNodeType.Element) ? (e as XElement).WithoutNamespaces() : e;
            Func<XElement, IEnumerable<XAttribute>> getAttributes = e => (e.HasAttributes) ?
                e.Attributes()
                    .Where(a => !a.IsNamespaceDeclaration)
                    .Select(a => new XAttribute(a.Name.LocalName, a.Value))
                :
                Enumerable.Empty<XAttribute>();
            #endregion
        return new XElement(element.Name.LocalName,
            element.Nodes().Select(getChildNode),
            getAttributes(element));
    }

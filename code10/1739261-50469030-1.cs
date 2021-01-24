    var xml = @"<root xmlns:xyz='do/not/change' xmlns='add/alias'>
       <name>Test</name>
       <xyz:id>100</xyz:id>
    </root>";
    var xdoc = XDocument.Parse(xml);
    var xn = xdoc.Root.GetDefaultNamespace();
    xdoc.Root.SetAttributeValue(XNamespace.Xmlns + "abc", xn.NamespaceName);
    xdoc.Root.Attribute("xmlns").Remove();
    foreach (var el in xdoc.Root.DescendantsAndSelf())
    {
        if (el.Name.Namespace == xn)
        {
            el.Name = xn + el.Name.LocalName;
        }
    }

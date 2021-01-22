    var sb = new StringBuilder();
    var writer = XmlWriter.Create(sb, new XmlWriterSettings
    {
        Indent = true,
        ConformanceLevel = ConformanceLevel.Fragment,
        OmitXmlDeclaration = true,
        NamespaceHandling = NamespaceHandling.OmitDuplicates, 
    });
    var mgr = new XamlDesignerSerializationManager(writer);
    // HERE BE MAGIC!!!
    mgr.XamlWriterMode = XamlWriterMode.Expression;
    System.Windows.Markup.XamlWriter.Save(this, mgr);
    _shouldSerializeContent = true;
    return sb.ToString();

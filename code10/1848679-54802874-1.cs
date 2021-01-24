    var settings = new XmlReaderSettings { NameTable = new NameTable() };
    var xmlns = new XmlNamespaceManager(settings.NameTable);
    // here
    xmlns.AddNamespace("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
    xmlns.AddNamespace("x", "http://schemas.microsoft.com/winfx/2006/xaml");
    var context = new XmlParserContext(null, xmlns, "", XmlSpace.Default);
    var xmlReader = XmlReader.Create(stringReader, settings, context);
    viewbox.Child = (UIElement)System.Windows.Markup.XamlReader.Load(xmlReader);

    XPathDocument doc = new XPathDocument("data2.xml");
    XPathNavigator nav = doc.CreateNavigator();
    XmlNamespaceManager mgr = new XmlNamespaceManager(nav.NameTable);
    mgr.AddNamespace("default", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
    XPathNodeIterator iterator = nav.Select("//default:MenuItem[@Header][@Name]", mgr);
    while (iterator.MoveNext())
    {
        Console.Write(iterator.Current.GetAttribute("Header", ""));
        Console.Write(iterator.Current.GetAttribute("Name", ""));
        Console.Write(Environment.NewLine);
    }

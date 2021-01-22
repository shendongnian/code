    XPathDocument doc = new XPathDocument("data.xml");
    XPathNavigator nav = doc.CreateNavigator();
    XPathExpression expr = nav.Compile("//MenuItem[@Header][@Name]");
    XPathNodeIterator iterator = nav.Select(expr);
    while (iterator.MoveNext())
    {
        Console.Write(iterator.Current.GetAttribute("Header", ""));
        Console.Write(iterator.Current.GetAttribute("Name", ""));
        Console.Write(Environment.NewLine);
    }

    static void DisplayMessages(XElement root)
    {
        var items = root.Descendants(XName.Get("Item", root.GetDefaultNamespace().NamespaceName));
        foreach (var item in items)
        {
            var name = item.Element(XName.Get("Name", item.GetNamespaceOfPrefix("a").NamespaceName));
            Console.WriteLine(name.Value);
        }
    }

    static void DisplayMessages(XElement root)
    {
        var items = root.Descendants(root.GetDefaultNamespace() + "Item");
        foreach (var item in items)
        {
            var name = item.Element(item.GetNamespaceOfPrefix("a") + "Name");
            Console.WriteLine(name.Value);
        }
    }

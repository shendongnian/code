    static string AppendPrefix(string oldPrefix, string addition) =>
        oldPrefix == "" ? addition : $"{oldPrefix}.{addition}";
    static void CompareElements(string prefix, XElement d1, XElement d2)
    {
        // 1. compare names
        var newPrefix = AppendPrefix(prefix, d1.Name.ToString());
        if (d1.Name != d2.Name)
        {
            Console.WriteLine(
                $"Name mismatch: {newPrefix} != {AppendPrefix(prefix, d2.Name.ToString())}");
            return;
        }
        // 2. compare attributes
        var attrs = d1.Attributes().OrderBy(a => a.Name);
        var unpairedAttributes = new HashSet<XAttribute>(d2.Attributes());
        foreach (var attr in attrs)
        {
            var otherAttr = d2.Attributes(attr.Name).SingleOrDefault();
            if (otherAttr == null)
            {
                Console.WriteLine($"No new attr: {newPrefix}/{attr.Name}");
                continue;
            }
            unpairedAttributes.Remove(otherAttr);
            if (attr.Value != otherAttr.Value)
                Console.WriteLine(
                    $"Attr value mismatch: {newPrefix}/{attr.Name}: {attr.Value} != {otherAttr.Value}");
        }
        foreach (var attr in unpairedAttributes)
            Console.WriteLine($"No old attr: {newPrefix}/{attr.Name}");
        // 3. compare subelements
        var leftNodes = d1.Nodes().ToList();
        var rightNodes = d2.Nodes().ToList();
        var smallerCount = Math.Min(leftNodes.Count, rightNodes.Count);
        for (int i = 0; i < smallerCount; i++)
            CompareNodes(newPrefix, i, leftNodes[i], rightNodes[i]);
        if (leftNodes.Count > smallerCount)
            Console.WriteLine($"Extra {leftNodes.Count - smallerCount} nodes at old file");
        if (rightNodes.Count > smallerCount)
            Console.WriteLine($"Extra {rightNodes.Count - smallerCount} nodes at new file");
    }
    static void CompareNodes(string prefix, int index, XNode n1, XNode n2)
    {
        if (n1.NodeType != n2.NodeType)
        {
            Console.WriteLine($"Node type mismatch: {prefix}/[{index}]");
            return;
        }
        switch (n1.NodeType)
        {
            case XmlNodeType.Element:
                CompareElements(prefix, (XElement)n1, (XElement)n2);
                break;
            case XmlNodeType.Text:
                CompareText(prefix, index, (XText)n1, (XText)n2);
                break;
        }
    }
    static void CompareText(string prefix, int index, XText t1, XText t2)
    {
        if (t1.Value != t2.Value)
            Console.WriteLine($"Text mismatch at {prefix}[{index}]");
    }

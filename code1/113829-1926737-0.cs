    foreach (var elm in e.Descendants()
       .Where(p => p.Attribute("text").Value == "Design")
       .Select(p => new {Node = p, Parent = p.Parent}))
    {
        Console.WriteLine(elm.Node);
        Console.WriteLine(elm.Parent);
    }

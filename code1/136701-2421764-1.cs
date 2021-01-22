    public void Run()
    {
        XDocument doc = XDocument.Load(fileToLoad);
        System.Console.WriteLine("\nSumming:");
        var sum = doc.Element("nodes")
                     .Elements("reading")
                     .Sum(n => int.Parse(n.Value));
        Console.WriteLine("  {0}", sum);
    }

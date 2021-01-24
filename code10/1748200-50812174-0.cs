    var items = osmFile.Root
        .Elements("way")
        .Select(x => x.Elements("nd")
                        .Select(z => z.Attribute("ref").Value));
    
    foreach (var item in items)
    {
        MessageBox.Show(string.Join(Environment.NewLine, item));
    }

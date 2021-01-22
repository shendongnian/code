    foreach (string pageName in pageNames)
    {
        string xaml = File.ReadAllText(pageName);
        Page thePage = XamlReader.Load(xaml);
        thePages.Add(thePage);
    }

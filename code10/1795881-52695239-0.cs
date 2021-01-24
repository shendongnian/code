    private List<string> GetFilesForFont(string fontName)
    {
        var fontNameToFiles = new Dictionary<string, List<string>>();
        foreach (var fontFile in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Fonts)))
        {
            var fc = new PrivateFontCollection();
            if (File.Exists(fontFile))
                fc.AddFontFile(fontFile);
            if ((!fc.Families.Any()))
                continue;
            var name = fc.Families[0].Name;
            // If you care about bold, italic, etc, you can filter here.
            if (! fontNameToFiles.TryGetValue(name, out var files))
            {
                files = new List<string>();
                fontNameToFiles[name] = files;
            }
            files.Add(fontFile);
        }
        if (!fontNameToFiles.TryGetValue(fontName, out var result))
            return null;
        return result;
    }

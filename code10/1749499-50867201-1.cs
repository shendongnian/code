    public void CreateSingle()
    {
        string source = Path.Combine(Common.templatePath, "Text files", "File.txt");
        string dest = Path.Combine(Common.PathToTextFile, CreateTextFile.TextName);
        string text = File.ReadAllText(source)
            .Replace("100", createText.Price)
            .Replace("10", createText.Unlock)
            .Replace("true1", createText.Stock)
       File.WriteAlltext(dest, text)
    }

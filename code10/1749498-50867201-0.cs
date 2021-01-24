    public void CreateSingle()
    {
        string path = Common.PathToTextFile + CreateTextFile.TextName;
        string text = File.ReadAllText(Common.templatePath + "Text files\\"+ "File.txt")
            .Replace("100", createText.Price)
            .Replace("10", createText.Unlock)
            .Replace("true1", createText.Stock)
           File.WriteAlltext(path, text)
    }

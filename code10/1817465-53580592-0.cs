    string globalizationPrefix = "Globalization = ";
    string globalizationLine = File.ReadAllLines(filePath)
        .Where(l => l.StartsWith(globalizationPrefix ))
        .FirstOrDefault();
    if(globalizationLine != null)
    {
        int index = globalizationPrefix.Length;
        string globalizationValue = globalizationLine.Substring(index);
        label1.Text = globalizationValue;
    }

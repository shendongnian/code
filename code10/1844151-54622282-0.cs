    public string FileChange()
    {
        var lines = content.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(line => line.Contains("ocean") ? $"{line} water" : line);
        return string.Join("\n", lines);
    }

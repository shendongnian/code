    public static string GetTextAfterMarker(string line, string marker)
    {
        var items = line.Split(new[] {marker}, StringSplitOptions.None);
    
        string result = items[items.Length-1];
        return line.Equals(result) ? string.Empty : result;
    }

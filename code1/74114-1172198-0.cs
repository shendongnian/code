    public static string GetTextAfterMarker(string line, string marker)  {
        int pos = line.IndexOf(marker);
        if (pos == -1)
           return string.Empty;
        return line.Substring(0,pos);
    }

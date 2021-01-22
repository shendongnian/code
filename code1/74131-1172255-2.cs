    public static string GetTextAfterMarker(string line, string marker)
    {
        int index = line.IndexOf(marker);
        return index < 0 ? string.Empty : line.Substring(index + marker.Length);
    }

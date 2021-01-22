    public static string GetTextAfterMarker(string line, string marker)
    {
        string[] tmp = line.Split(new string[] { marker }, StringSplitOptions.None);
        string result = tmp[tmp.Count-1];
        return line.Equals(result) ? string.Empty : result;
    }

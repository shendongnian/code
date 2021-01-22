    public static string GetTextAfterMarker(string line, string marker)
    {
        string result = line.Split(new string[] { marker }, StringSplitOptions.None)[line.Split(new string[] { marker }, StringSplitOptions.None).Count()-1];
        return line.Equals(result) ? string.Empty : result;
    }

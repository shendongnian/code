    public static string GetTextAfterMarker2(string line, string marker)
    {
      string result = line.Split(new string[] { marker }, StringSplitOptions.None).Last();
      return line.Equals(result) ? string.Empty : result;
    }

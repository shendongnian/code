    public static string GetTextBeforeMarker(string line, string marker)
    {
        if (line == null)
        {
            throw new ArgumentNullException("line");
        }
    
        if (marker == null)
        {
            throw new ArgumentNullException("marker");
        }
        
        string result = line.Split(new string[] { marker }, StringSplitOptions.None)[0];
        return line.Equals(result) ? string.Empty : result;
    }

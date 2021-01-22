    public static List<string> StraightProcess(List<string> urls)
    {
        List<string> result = new List<string>();
        foreach (string url in urls)
        {
            result.Add(url);
            result.AddRange(GetLinks(url));
        }
        return result;
    }

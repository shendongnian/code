    public static string UrlCombine(string part1, string part2)
    {
        string newPart1 = string.Empty;
        string newPart2 = string.Empty;
        string seprator = "/";
    
        // if either part1 or part 2 is empty,
        // we don't need to combine with seprator
        if (string.IsNullOrEmpty(part1) || string.IsNullOrEmpty(part2))
        {
            seprator = string.Empty;
        }
    
        // if part1 is not empty
        // remove '/' at last
        if (!string.IsNullOrEmpty(part1))
        {
            newPart1 = part1.TrimEnd('/');
        }
    
        // if part2 is not empty
        // remove '/' at first
        if (!string.IsNullOrEmpty(part2))
        {
            newPart2 = part2.TrimStart('/');
        }
    
        // now finally combine
        return string.Format("{0}{1}{2}", newPart1, seprator, newPart2);
    }

     private List<string> checkifMatch(List<string> lst1, List<string> lst2)
    {
        List<string> matches= new List<string>();
        matches.AddRange(lst1.Except(lst2, StringComparer.OrdinalIgnoreCase));
        matches.AddRange(lst2.Except(lst1, StringComparer.OrdinalIgnoreCase));
        return matches;
    }

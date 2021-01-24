    public List<List<string>> FilterStrings()
    {
        List<List<string>> list = new List<List<string>>();
        list.Add(new List<string> { "One", "Two", "", "Eight" });
        list.Add(new List<string> { "Three", "Five", "Six" });
        list.Add(new List<string> { "Sixteen", "", "" });
        list.Add(new List<string> { "Twenty-Eight", "Forty", "Nine" });
        return list.Select(lst => lst.Where(str => !string.IsNullOrEmpty(str)).ToList()).ToList();
    }

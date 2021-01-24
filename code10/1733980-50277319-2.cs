    public IList<string> ExctractListIds(string command)
    {
        int temp;
        return command?.Split().Where(item => int.TryParse(item, out temp)).ToList() ?? 
            new List<string>();
    }

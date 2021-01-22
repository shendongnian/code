    public IEnumerable<string> EnumerateUntilEmpty()
    {
        foreach (var name in nameList)
        {
            if (String.IsNullOrEmpty(name)) yield break;
            yield return name;
        }     
    }

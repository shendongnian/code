    public bool ParseAndCheck(string source,
        out IList<int> goodItems, out IList<string> badItems)
    {
        goodItems = new List<int>();
        badItems = new List<string>();
        foreach (string item in source.Split(','))
        {
            int temp;
            if (int.TryParse(item, out temp))
                goodItems.Add(temp);
            else
                badItems.Add(item);
        }
        return (badItems.Count < 1);
    }

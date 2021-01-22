        List<int> a = new List<int>() { 1, 2, 3, 4, 5, 12, 13 };
        List<int> b = new List<int>() { 0, 4, 8, 12 };
        List<int> intersection = new List<int>();
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        a.ForEach(x => { if(!dictionary.ContainsKey(x))dictionary.Add(x, 0); });
        b.ForEach(x => { if(dictionary.ContainsKey(x)) dictionary[x]++; });
        foreach(var item in dictionary)
        {
            if(item.Value > 0)
                intersection.Add(item.Key);
        }

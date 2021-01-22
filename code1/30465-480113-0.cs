    List<int> a = new List<int>() { 1, 2, 3, 4, 5 };
    List<int> b = new List<int>() { 0, 4, 8, 12 };
    List<int> shortestList;
    List<int> longestList;
    if (a.Count > b.Count)
    {
        shortestList = b;
        longestList = a;
    }
    else
    {
        shortestList = a;
        longestList = b;                
    }
    Dictionary<int, bool> dict = new Dictionary<int, bool>();
    shortestList.ForEach(x => dict.Add(x, true));
    foreach (int i in longestList)
    {
        if (dict.ContainsKey(i))
        {
            Console.WriteLine(i);
        }
    }

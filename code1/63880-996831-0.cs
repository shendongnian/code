    char[] myArray = new char[] { 'a', 'b', 'c', 'c' };
    char[] urArray = new char[] { 'a', 'b', 'c' ,'a' };
    Console.WriteLine(AreEqual(myArray, urArray));    // False
    // ...
    public bool AreEqual<T>(IEnumerable<T> first, IEnumerable<T> second)
    {
        Dictionary<T, int> map = new Dictionary<T, int>();
        foreach (T item in first)
        {
            if (map.ContainsKey(item))
                map[item]++;
            else
                map[item] = 1;
        }
        foreach (T item in second)
        {
            if (map.ContainsKey(item))
                map[item]--;
            else
                return false;
        }
        foreach (int i in map.Values)
        {
            if (i != 0)
                return false;
        }
        return true;
    }

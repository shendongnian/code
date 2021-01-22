    static List<T> RemoveDuplicates<T>(List<T> input)
    {
        List<T> result = new List<T>(input.Count);
        Dictionary<T, object> hashSet = new Dictionary<T, object>();
        foreach (T s in input)
        {
            if (!hashSet.ContainsKey(s))
            {
                result.Add(s);
                hashSet.Add(s, null);
            }
        }
        return result;
    }

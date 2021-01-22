    static void Main(string[] args)
    {
        IList list = new List<int>() { 1, 3, 2, 5, 4, 6, 9, 8, 7 };
        List<int> stronglyTypedList = new List<int>(Cast<int>(list));
        stronglyTypedList.Sort();
    }
    
    private static IEnumerable<T> Cast<T>(IEnumerable list)
    {
        foreach (T item in list)
        {
            yield return item;
        }
    }

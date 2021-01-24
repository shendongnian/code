    static void Main(string[] args)
    {
        string[] t1 = new string[] { "a", "b", "c" };
        string[] t2 = new string[] { "a1", "a2", "b1", "b2", "c1", "c2" };
        List<string> merged = Merge(t1.ToList(), t2.ToList());
        foreach (string item in merged)
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
    private static List<T> Merge<T>(List<T> first, List<T> second)
    {
        List<T> ret = new List<T>();
        for (int indexFirst = 0, indexSecond = 0; 
            indexFirst < first.Count && indexSecond < second.Count; 
            indexFirst++, indexSecond+= 2)
        {
            ret.Add(first[indexFirst]);
            ret.Add(second[indexSecond]);
            ret.Add(second[indexSecond + 1]);
        }
        return ret;
    }

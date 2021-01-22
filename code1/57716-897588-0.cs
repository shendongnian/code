    static void Main(string[] args)
    {
        var arr1 = new[] { 1, 2, 3, 4, 5 };
        var arr2 = new[] { 1, 2, 4, 4, 5 };
        Console.WriteLine("Arrays are equal: {0}", equals(arr1, arr2));
    }
    private static bool equals(IEnumerable arr1, IEnumerable arr2)
    {
        var enumerable1 = arr1.OfType<object>();
        var enumerable2 = arr2.OfType<object>();
        if (enumerable1.Count() != enumerable2.Count())
            return false;
        var iter1 = enumerable1.GetEnumerator();
        var iter2 = enumerable2.GetEnumerator();
        while (iter1.MoveNext() && iter2.MoveNext())
        {
            if (!iter1.Current.Equals(iter2.Current))
                return false;
        }
                    
        return true;
    }

    public static bool AllSame<T>(List<T> values)
    {
       List<T> lst = new List<T>();
       foreach(T obj in values)
           lst.Add(obj);
       return lst.Distinct().Count() == 1;
    }

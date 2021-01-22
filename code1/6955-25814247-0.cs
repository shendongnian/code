    public static Dictionary<int, string> ToList<T>() where T : struct
    {
       return ((IEnumerable<T>)Enum
           .GetValues(typeof(T)))
           .ToDictionary(
               item => Convert.ToInt32(item),
               item => item.ToString());
    }

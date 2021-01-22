    void Main() 
    {
      var intArray = new [] { 1, 3, 2, 5, 1 };
      var ints = Sort(intArray.AsEnumerable(), x => SortInt(x)); 
      var nextInts = Sort(intArray.AsEnumerable(), SortInt); 
    }
    public static IEnumerable<T> Sort<T>(
                  IEnumerable<T> toBeSorted, 
                  Func<IEnumerable<T>, IEnumerable<T>> sortFunc) 
    {        
       return sortFunc(toBeSorted);
    }
    public static IOrderedEnumerable<T> SortInt<T>(IEnumerable<T> array) 
    {    
        return array.OrderByDescending(x => x);
    }

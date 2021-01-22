      void Main() {
    	var intArray = new [] { 1, 3, 2, 5, 1 };
    	var ints = Sort(intArray.AsEnumerable(), x => SortInt(x)); 
    	var nextInts = Sort<int, int>(intArray.AsEnumerable(), SortInt); 
       }
    	
       public static IEnumerable<TResult> Sort<T, TResult>(
                     IEnumerable<T> toBeSorted, 
                     Func<IEnumerable<T>, IEnumerable<TResult>> sortFunc)
       {    
          return sortFunc(toBeSorted);
       }
       public static IOrderedEnumerable<int> SortInt(IEnumerable<int> array){    
          return array.OrderByDescending(x => x);
       }

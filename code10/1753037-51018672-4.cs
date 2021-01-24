    public class Backs : Benchmark<Tuple<List<int>, List<int>>, List<int>>
    {
       protected override List<int> InternalRun()
       {
          var setAsHash = new HashSet<int>();
          Input.Item1.ForEach(x =>
             {
                if (setAsHash.Contains(x))
                   return;
    
                setAsHash.Add(x);
             });
          setAsHash.ExceptWith(Input.Item2); // This is ultimately what we're testing
    
          return setAsHash.ToList();
       }
    }
    
    public class HasSet : Benchmark<Tuple<List<int>, List<int>>, List<int>>
    {
    
       protected override List<int> InternalRun()
       {
          var hashSet = new HashSet<int>(Input.Item2); 
    
          return Input.Item1.Where(y => !hashSet.Contains(y)).ToList(); 
       }
    }
    
    public class Todd : Benchmark<Tuple<List<int>, List<int>>, List<int>>
    {
       protected override List<int> InternalRun()
       {
          var referenceHashSet = Input.Item2.Distinct()                 
                                          .ToDictionary(x => x, x => x);
    
          return Input.Item1.Where(y => !referenceHashSet.TryGetValue(y, out _)).ToList();
       }
    }
    
    public unsafe class HashSetUnsafe : Benchmark<Tuple<List<int>, List<int>>, List<int>>
    {
       protected override List<int> InternalRun()
       {
          var reference = new HashSet<int>(Input.Item2);
          var result = new HashSet<int>();
          fixed (int* pAry = Input.Item1.ToArray())
          {
             var len = pAry+Input.Item1.Count;
             for (var p = pAry; p < len; p++)
             {
                if(!reference.Contains(*p))
                   result.Add(*p);
             }
          }
          return result.ToList(); 
       }
    }
    public unsafe class ListUnsafe : Benchmark<Tuple<List<int>, List<int>>, List<int>>
    {
       protected override List<int> InternalRun()
       {
          var reference = new HashSet<int>(Input.Item2);
          var result = new List<int>(Input.Item2.Count);
    
          fixed (int* pAry = Input.Item1.ToArray())
          {
             var len = pAry+Input.Item1.Count;
             for (var p = pAry; p < len; p++)
             {
                if(!reference.Contains(*p))
                   result.Add(*p);
             }
          }
          return result.ToList(); 
       }
    }
    
    public unsafe class ArrayUnsafe : Benchmark<Tuple<List<int>, List<int>>, List<int>>
    {
       protected override List<int> InternalRun()
       {
          var reference = new HashSet<int>(Input.Item2);
          var result = new int[Input.Item1.Count];
    
          fixed (int* pAry = Input.Item1.ToArray(), pRes = result)
          {
             var j = 0;
             var len = pAry+Input.Item1.Count;
             for (var p = pAry; p < len; p++)
             {
                if(!reference.Contains(*p))
                   *(pRes+j++) = *p;
             }
             return result.Take(j).ToList(); 
          }
    
       }
    }

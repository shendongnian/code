    class Program
    {
    
       public sealed class Test
       {
          public String Data { get; set; }
          public override string ToString()
          {
             return Data;
          }
       }
    
       static void Main(string[] args)
       {
          TestRun(100000);
          TestRun(1000000);
          TestRun(10000000);
       }
    
       private static void TestRun(int iterations)
       {
          var toString = typeof(Test).GetMethod("ToString",
                                                BindingFlags.Instance
                                                | BindingFlags.Public,
                                                null,
                                                Type.EmptyTypes,
                                                null);
          var call = GetCall<Test, String>(toString);
          var tests
             = (from i in Enumerable.Range(1, iterations)
                select new Test { Data = "..." + i }).ToList();
    
          var sw = Stopwatch.StartNew();
          tests.ForEach(i => call(i));
          sw.Stop();
          Console.WriteLine("{0} iterations took {1} ms", iterations, sw.ElapsedMilliseconds);
       }
    
       private static Func<T, M> GetCall<T, M>(MethodInfo methodInfo)
       {
          var input = Expression.Parameter(typeof(T), "input");
          MethodCallExpression member = Expression.Call(input, methodInfo);
          var lambda = Expression.Lambda<Func<T, M>>(member, input);
    
          return lambda.Compile();
       }
    }

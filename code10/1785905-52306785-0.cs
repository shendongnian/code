    static void Main(string[] args)
    {
       var result = Combos(10);
       foreach (var num in result)
       {
          Console.WriteLine(num);
       }
    }
        
    static Dictionary<long, IEnumerable<int>> cache = new Dictionary<long, IEnumerable<int>>();
    public static IEnumerable<int> Combos(int n)
    {           
        if (n < 3)
        {
           yield return n;
        }
        else
        {
           if (!cache.TryGetValue(n - 1, out IEnumerable<int> combos1))
           {
               combos1 = Combos(n - 1);
               cache.Add(n - 1, combos1);
           }
           if (!cache.TryGetValue(n - 2, out IEnumerable<int> combos2))
           {
               combos2 = Combos(n - 2);
               cache.Add(n - 2, combos2);
           }
           foreach (var number1 in combos1)
                 yield return number1;
           foreach (var number2 in combos2)
                 yield return number2;
         }
    }

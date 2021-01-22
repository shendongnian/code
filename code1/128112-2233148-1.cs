    class Sample
    {
     public static void Run()
     {
         int i = 1;
         Func<int, int> change = Increment();
         for (int x = 0; x < 5; x++ )
         {
             i = change(i);
             Console.WriteLine("value=" + i.ToString());
         }
     }
    
     public static Func<int, int> Increment()
     {
          return delegate(int i) { return ++i; };
     }
    }

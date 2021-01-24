    public static void TryCatchLogError<T>(this T item, Action action)
    {
       try
       {
          action();
       }
       catch (Exception ex)
       {
         // LogError(ex);
       }
    }
    
    private static void Main() => 
       TryCatchLogError("asd",  // <== here needs to be T Item
          () =>
             {
                Console.WriteLine("asdasd");
             });
    
       

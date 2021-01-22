    myEnumerable.Select(a => TryThisMethod(a));
    ...
    public static Bar TryThisMethod(Foo a)
    {
         try
         {
             return ThisMethodMayThrowExceptions(a);
         }
         catch(BarNotFoundException)
         {
             return Bar.Default;
         }
    }

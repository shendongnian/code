    class SomeOtherClass : SomeClass, ISomeInterface
    {
       public static IEnumerable<SomeClass> GetSomeStuff()
       {
          for( int i = 0; i<10; ++i)
             yield return new SomeOtherClass(i);
       }
    }

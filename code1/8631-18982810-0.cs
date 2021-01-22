    //The GetType method is invoked on an object and is resolved at run time.
    //The first is used when you need to use a known Type, the second is to get 
      //   the type of an object when you don't know what it is.
    class BaseClass
    { }
    class DerivedClass : BaseClass
    { }
    class FinalClass
    {
        static void RevealType(BaseClass baseCla)
        {
            Console.WriteLine(typeof(BaseClass));  // compile time
            Console.WriteLine(baseCla.GetType());  // run time
        }
        static void Main(string[] str)
        {
            RevealType(new BaseClass());
            Console.ReadLine();
        }
    }

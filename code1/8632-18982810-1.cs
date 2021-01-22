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
    // *********  By Praveen Kumar Srivastava 

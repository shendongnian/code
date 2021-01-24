    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static Type T; //Not needed
            public class TypeA
            {
                public int testProp { get; set; }
                public string testPropTwo { get; set; }
            }
            public class TypeB
            {
                public decimal testProp { get; set; }
                public bool testPropTwo { get; set; }
            }
            static void Main(string[] args)
            {
                TypeA typeA = new TypeA();
                TypeB typeB = new TypeB();
                //Read type of user input. Mimicking dynamic value
                var inputType = Console.ReadLine();
                //Comparison with types.
                Console.WriteLine(typeA.GetType().Name == inputType);
                Console.WriteLine(typeB.GetType().Name == inputType);
                Console.ReadKey();
            }
        }
    }

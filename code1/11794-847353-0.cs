    namespace Craft
    {
        enum Symbol { Alpha = 1, Beta = 2, Gamma = 3, Delta = 4 };
    
    
       class Mate
        {
            static void Main(string[] args)
            {
    
                JustTest(Symbol.Alpha); // enum
                JustTest(0); // why enum
                JustTest((int)0); // why still enum
    
                int i = 0;
    
                JustTest(Convert.ToInt32(0)); // have to use Convert.ToInt32 to convince the compiler to make the call site use the object version
    
                JustTest(i); // it's ok from down here and below
                JustTest(1);
                JustTest("string");
                JustTest(Guid.NewGuid());
                JustTest(new DataTable());
    
                Console.ReadLine();
            }
    
            static void JustTest(Symbol a)
            {
                Console.WriteLine("Enum");
            }
    
            static void JustTest(object o)
            {
                Console.WriteLine("Object");
            }
        }
    }

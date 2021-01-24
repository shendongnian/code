    using System;
    
    class Test
    {
        const int ClassConst = 10;
        
        static void PrintLocalConst()
        {
            const int LocalConst = 10;
            Console.WriteLine(LocalConst);
            Console.WriteLine(LocalConst);
        }
    
        static void PrintClassConst()
        {
            Console.WriteLine(ClassConst);
            Console.WriteLine(ClassConst);
        }
    }

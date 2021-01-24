    using System;
    
    class Test
    {
        static void Main()
        {
            // Use whichever you want to demonstrate...
            RecurseSmall(1);
            //RecurseLarge(1);
        }
        
        static void RecurseSmall(int depth)
        {
            Console.WriteLine(depth);
            RecurseSmall(depth + 1);
        }
        
        static void RecurseLarge(int depth)
        {
            Console.WriteLine(depth);
            RecurseLarge(depth + 1);
            
            // Create some local variables and try to avoid them being 
            // optimized away... We'll never actually reach this code, but
            // the compiler and JIT compiler don't know that, so they still
            // need to allocate stack space.
            long x = 10L + depth;
            long y = 20L + depth;
            decimal dx = x * depth + y;
            decimal dy = x + y * depth;
            Console.WriteLine(dx + dy);
        }
    }

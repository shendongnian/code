    using System;
    
    class Test
    {
        static void Main()
        {
            string first = new string(new[] {'x'});
            string second = new string(new[] {'y'});
            
            string.Intern(first); // Interns it
            Console.WriteLine(string.IsInterned(first) != null); // Check
    
            string.IsInterned(second); // Doesn't intern it
            Console.WriteLine(string.IsInterned(second) != null); // Check
        }
    }

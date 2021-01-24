    using System;
    
    class Test
    {
        static void Main()
        {
            dynamic d = new Test();
            
            // Variables we want to deconstruct into
            string text;
            int number;
            
            // Approach 1: Casting
            (text, number) = ((string, int)) d.Method();
    
            // Approach 2: Assign to a tuple variable first
            (string, int) tuple = d.Method();
            (text, number) = tuple;
            
        }
        
        public (string, int) Method() => ("text", 5);
    }

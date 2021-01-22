    using System;
    using System.Collections.Generic;
    
    class Dummy
    {
        public int Value { get; set; }
        
        public Dummy (int value)
        {
            this.Value = value;
        }
    }
    
    class Test
    {
        static void Main()
        {
            List<Dummy> originalList = new List<Dummy> 
            {
                new Dummy(5),
                new Dummy(6),
                new Dummy(7)
            };
            
            List<Dummy> cloneList = new List<Dummy>(originalList);
            
            cloneList[0].Value = 1;
            cloneList[1] = new Dummy(2);
            Console.WriteLine(originalList[0].Value); // Changed to 1
            Console.WriteLine(originalList[1].Value); // Still 6
        }
    }

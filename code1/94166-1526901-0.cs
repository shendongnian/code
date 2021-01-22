    class Test { 
       public override string ToString() { return "Hello World"; }
       public string M1() { return ToString(); } // Test.ToString
       public string M2() { return base.ToString(); } // System.Object.ToString
       static void Main() { 
           var t = new Test();
           Console.WriteLine("M1: {0}", M1()); // Hello World
           Console.WriteLine("M2: {0}", M2()); // Test
       }
    }

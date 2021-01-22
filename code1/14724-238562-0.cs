    using System;
    using System.Reflection;
    
    public class Test
    {
        // public just for the sake of a short example.
        public int x;
        
        static void Main()
        {
            FieldInfo field = typeof(Test).GetField("x");
            Test t = new Test();
            t.x = 10;
            
            Console.WriteLine(field.GetValue(t));
        }
    }

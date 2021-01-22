    using System;
    
    class MyClass
    {
        public static void Swap(ref Object obj1, ref Object obj2) // Use keyword 'ref'
        {
            Console.WriteLine("After Swapping");
            obj1 = 100;
            obj2 = 200;
        }
    }
    
    class MainClass 
    {
        static void Main(string[] args) 
        {
            Object obj1 = new Object ();
            obj1 = 10;
    
            Object obj2 = new Object ();
            obj2 = 20;
    
            Console.WriteLine(obj1.ToString());
            Console.WriteLine(obj2.ToString());
    
            MyClass.Swap(ref obj1, ref obj2); // Use keyword 'ref'
    
            Console.WriteLine(obj1.ToString());
            Console.WriteLine(obj2.ToString());
    
            Console.ReadLine();
        }
    }

    using System;
    
    interface A
    
    {
            void Hello();
    }
    
    interface B
    
    {
        void Hello();
    }
    
     
    class Test : A, B
    
    {
        void A.Hello()
    
        {
            Console.WriteLine("Hello to all-A");
        }
    
        void B.Hello()
        {
            Console.WriteLine("Hello to all-B");
    
        }
    
    }
    
    public class interfacetest
    
    {
        public static void Main()
    
        {
            A Obj1 = new Test();
    
            Obj1.Hello();
            B Obj2 = new Test();
    
            Obj2.Hello();
        }
    
    }

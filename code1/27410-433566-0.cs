    using System;
    
    class Base {}
    class Child : Base {}
    
    class Test
    {
        static void Main()
        {
            Base b = new Base();
            
            // This will throw an exception
            Child c = (Child) b; 
        }
    }

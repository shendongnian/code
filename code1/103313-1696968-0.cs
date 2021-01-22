    using System;
    using System.Text;
    
    class Test    
    {    
        static void PassByValue(StringBuilder x)
        {
            x.Append(" - Modified object in method");
            x = new StringBuilder("New StringBuilder object");
        }
    
        static void PassByReference(ref StringBuilder x)
        {
            x.Append(" - Modified object in method");
            x = new StringBuilder("New StringBuilder object");
        }
        
        static void Main()
        {
            StringBuilder builder = new StringBuilder("Original");
            PassByValue(builder);
            Console.WriteLine(builder);
            
            builder = new StringBuilder("Original");
            PassByReference(ref builder);
            Console.WriteLine(builder);
        }
    }

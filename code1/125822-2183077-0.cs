    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                TheForm tf1 = new TheFormWithStatus(DateTime.Now, "online");
                TheForm tf2 = new TheFormWithID(DateTime.Now, "form1");
            }
        }
    
        public class TheForm
        {
            public TheForm(DateTime startTime)
            {
               //...
            }
    
        }
    
        public class TheFormWithID : TheForm
        {
            public TheFormWithID (DateTime startTime, string idCode) : TheForm (startTime)
            {
               //...
            }
        }
    
        public class TheFormWithStatus : TheForm
        {
            public TheFormWithID (DateTime startTime, string status) : TheForm (startTime)
            {
               //...
            }
        }
    }

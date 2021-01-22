    using System;
    
    namespace Test
    {
        class Program
        {
            public static void Sample(string string1, 
                string string2, 
                string string3, 
                System.Windows.Forms.MessageBoxButtons buttons)
            { }
            public static void Sample(string string1, 
                string[] string2, 
                string string3, 
                System.Windows.Forms.MessageBoxButtons buttons)
            { }
            
            static void Main()
            {
                string[] myStringArray = 
                    new string[] { "this is a test", "of overloaded methods" };
                Sample("String1", 
                    myStringArray, 
                    "String2", 
                    System.Windows.Forms.MessageBoxButtons.OK);
            }
       }
    }

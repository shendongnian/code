    using System;
    
    public class Test
    {
        static string foo;
        
        static void Main(string[] args)
        {
            foo = "First";
            ShowFoo();
            ChangeValue(ref foo);
            ShowFoo();
        }
        
        static void ShowFoo()
        {
            Console.WriteLine(foo);
        }
        
        static void ChangeValue(ref string x)
        {
            x = "Second";
            ShowFoo();
        }
    }

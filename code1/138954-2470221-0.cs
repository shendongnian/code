    using System;
    
    public class Driver
    {
    // Entry point of the program
        public static void Main(string[] Args)
        {
            Console.WriteLine(SayHello1("Hello to Me 1"));
            Console.WriteLine(SayHello2("Hello to Me 2"));
    
            Func<string, string> action1 = SayHello1;
            Func<string, string> action2 = SayHello2;
    
            MyAttribute myAttribute1 = (MyAttribute)Attribute.GetCustomAttribute(action1.Method, typeof(MyAttribute));
            MyAttribute myAttribute2 = (MyAttribute)Attribute.GetCustomAttribute(action2.Method, typeof(MyAttribute));
    
            Console.ReadLine();
        }
    
        [MyAttribute("hello")]
        public static string SayHello1(string str)
        {
            return str;
        }
    
        [MyAttribute("Wrong Key, should fail")]
        public static string SayHello2(string str)
        {
            return str;
        }
    
    
    }
    
    [AttributeUsage(AttributeTargets.Method)]
    public class MyAttribute : Attribute
    {
    
        public string MyProperty
        {
            get; set;
        }
    
        public string MyProperty2
        {
            get;
            set;
        }
    
        public MyAttribute(string VRegKey)
        {
            MyProperty = VRegKey;
            if (VRegKey == "hello")
            {
                Console.WriteLine("Aha! You're Registered");
            }
            else
            {
                throw new Exception("Oho! You're not Registered");
            };
    
            MyProperty2 = VRegKey;
        }
    }

    using System;
    
    class Program
    {    
        static void Main(string[] args)
        {
            Func<string> stringFactory = () => "hello";
            Func<object> objectFactory = () => new object();
            
            Func<object> multi1 = stringFactory;
            multi1 += objectFactory;
         
            Func<object> multi2 = objectFactory;
            multi2 += stringFactory;
        }    
    }

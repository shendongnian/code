    using System;
    class Test
    {
        static void Main()
        {
            CallFunc(Demo);
        }
        
        static int Demo() { return 5; }
        
        static T CallFunc<T>(Func<T> func)
        {
            return func();
        }
    }

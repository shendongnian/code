    using System;
    using System.Reflection;
    
    class Test
    {
        public void Foo(ref string x)
        {
        }
        
        static void Main()
        {
            MethodInfo method = typeof(Test).GetMethod("Foo");
            Type stringByRef = method.GetParameters()[0].ParameterType;
            Console.WriteLine(stringByRef);
            Type normalString = stringByRef.GetElementType();
            Console.WriteLine(normalString);        
        }
    }

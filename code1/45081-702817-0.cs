    using System;
    
    public class GenericType<TFirst, TSecond>
    {
        // Never use a public mutable field normally, of course.
        public static string Foo;
    }
    
    public class Test
    {    
        static void Main()
        {
            // Assign to different combination
            GenericType<string,int>.Foo = "string,int";
            GenericType<int,Guid>.Foo = "int,Guid";
            GenericType<int,int>.Foo = "int,int";
            GenericType<string,string>.Foo = "string,string";
            
            
            // Verify that they really are different variables
            Console.WriteLine(GenericType<string,int>.Foo);
            Console.WriteLine(GenericType<int,Guid>.Foo);
            Console.WriteLine(GenericType<int,int>.Foo);
            Console.WriteLine(GenericType<string,string>.Foo);
            
        }
    }

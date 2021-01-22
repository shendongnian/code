    using System;
    using System.Collections.Generic;
    namespace UsingStatement
    {
        using Typedeffed = System.Int32;
        using TypeDeffed2 = List<string>;
        class Program
        {
            static void Main(string[] args)
            {
            Typedeffed numericVal = 5;
            Console.WriteLine(numericVal++);
            TypeDeffed2 things = new TypeDeffed2 { "whatever"};
            }
        }
    }

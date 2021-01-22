    using System;
    using ExtensionMethodTest.Domain; //DON'T FORGET A NON-ALIASED USING
    using MyDomain = ExtensionMethodTest.Domain;
    
    namespace ExtensionMethodTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var m = new MyDomain.MyClass();
                var result = m.UpperCaseName();
            }
        }
    }

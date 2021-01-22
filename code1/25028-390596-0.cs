    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Runtime.Serialization;
    namespace NoConstructorThingy
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass myClass = (MyClass)FormatterServices.GetUninitializedObject(typeof(MyClass)); //does not call ctor
                myClass.One = 1;
                Console.WriteLine(myClass.One); //write "1"
                Console.ReadKey();
            }
        }
        public class MyClass
        {
            public MyClass()
            {
                Console.WriteLine("MyClass ctor called.");
            }
            public int One
            {
                get;
                set;
            }
        }
    }

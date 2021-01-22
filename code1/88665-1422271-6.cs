    using System;
    using OptionalLibrary;
    namespace TestReferences
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                if (args.Length > 0 && args[0] == "1") {
                    Talk talk = new Talk();
                    Console.WriteLine(talk.sayHello() + " " + talk.sayWorld() + "!");
                } else {
                    Console.WriteLine("2 Hello World!");
                }
            }
        }
    }

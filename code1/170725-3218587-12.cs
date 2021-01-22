    namespace ConsoleApplication1
    {
        using System;
        using AppleExtensionMethods;
    
        class Program
        {
            static void Main(string[] args)
            {
                Apple apple = new Apple();
    
                apple.SetSkinColor("Red");
                apple.SetSeedCount("8");
    
                Console.WriteLine("My apple is {0} and has {1} seed(s)\r\n", apple.GetSkinColor(), apple.GetSeedCount());
    
                apple.SetSkinColor("green");
                apple.SetSeedCount("4");
    
                Console.WriteLine("Now my apple is {0} and has {1} seed(s)\r\n", apple.GetSkinColor(), apple.GetSeedCount());
    
                apple.SetSkinColor("blue");
                apple.SetSeedCount("0");
    
                Console.WriteLine("Now my apple is {0} and has {1} seed(s)\r\n", apple.GetSkinColor(), apple.GetSeedCount());
    
                apple.SetSkinColor("yellow");
                apple.SetSeedCount("15");
    
                Console.WriteLine(apple.ToString());
    
                // Unfortunatly there is nothing stopping users of the class from doing something like that shown below.
                // This would be bad because it bypasses any behavior that you have defined in the get/set functions defined
                // as extension methods.
                // One thing in your favor here is it is inconvenient for user of the class to find the valid property names as
                // they'd have to go look at the apple class. It's much easier (from a lazy programmer standpoint) to use the
                // extension methods as they show up in intellisense :) However, relying on lazy programming does not a contract make.
                // There would have to be an agreed upon contract at the user of the class level that states, 
                //  "I will never use the indexer and always use the extension methods!"
                apple["Color"] = "don't panic";
                apple["SeedCount"] = "on second thought...";
    
                Console.WriteLine(apple.ToString());
            }
        }
    }

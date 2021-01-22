    using System;
    
    namespace Application
    {
        class Test
        {
            static void Main()
            {
                Item item1 = new Item("Item1", "Description...");
                Console.WriteLine(item1.Name);
                Console.WriteLine(item1.Description);
            }
        }
    }

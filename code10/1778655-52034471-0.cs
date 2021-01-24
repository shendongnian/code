    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    namespace ConsoleApp1
    {
        class Program
        {
            // Set a `wood` variable for the class.
            protected int wood { get; set; }
        
            static void Main(string[] args)
            {
                Program program = new Program(); // Making use of non-static methods.
                program.Handler();
            }
            public void Handler()
            {
                Console.WriteLine("Write \"gamble\" to hit the tree.");
                string message = Console.ReadLine();
                if (message == "gamble")
                {
                    addWood(); // Call the non-static method.
                }
            }
            public bool addWood()
            {
                this.wood = this.wood + 10;
                Console.WriteLine("You now have {0} wood!", this.wood);
            
                Handler(); // Call the Handler() method again for infinite loop.
                return true;
            }
        }
    }

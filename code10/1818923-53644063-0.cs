    static void Main(string[] args)
        {
            List<String> names = new List<string>(); // create a 20 name array
            string userInput;
            int maxNames = 0;
            while (maxNames != 20)
            {
                Console.WriteLine("Enter a bunch of names!"); // ask for a name
                userInput = Console.ReadLine(); // store the name in userInput
                if (userInput == "") // if the entry is null, stop taking names.
                {
                    Console.WriteLine("You entered {0}", names);
                    Console.ReadKey();
                }
                else if (userInput == "QUIT") // if the entry is QUIT, stop taking names.
                {
                    Console.WriteLine("You entered {0}", names);
                    Console.ReadKey();
                }
                names.Add(userInput);
                maxNames++;
                if(maxNames == 20)
                {
                    foreach (string name in names)
                    {
                        Console.WriteLine(name);
                    }
                    Console.ReadLine();
                }
            }
        }

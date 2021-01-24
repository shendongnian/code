    private static void Myfunc()
        {
            List<string> l = new List<string>();
            string opt = "y";
            while (opt == "y")
            {
                Console.WriteLine("Do you want to add in a specific position? (y/n)");
                string pos = Console.ReadLine();
                if (pos == "y")
                {
                    Console.WriteLine("Which index you want to add?");
                    int index = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Add items in {0}", index);
                    l.Insert(index, Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Enter to add in a list");
                    l.Add(Console.ReadLine());
                    Console.WriteLine("Do you wish to continue? (y/n)");
                    opt = Console.ReadLine();
                }
                Console.WriteLine("Do you want to print the list? (y/n)");
                string print = Console.ReadLine();
                if (print == "y")
                {
                    foreach (var item in l)
                    {
                        Console.WriteLine(item);
                    }
                }
            }

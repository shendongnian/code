    string sibling1, sibling2;
            int age_sibling1, age_sibling2;
            Console.WriteLine("Insert sibling 1 name ");
            sibling1 = Console.ReadLine();
            Console.WriteLine("Insert sibling 1 age ");
            age_sibling1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert sibling 2 name ");
            sibling2 = Console.ReadLine();
            Console.WriteLine("Insert sibling 2 age ");
            age_sibling2 = int.Parse(Console.ReadLine());
            if (age_sibling1 > age_sibling2)
                Console.WriteLine($"{sibling1} is bigger ");
            else
                Console.WriteLine($"{sibling2} is bigger ");
            // Wait for user.
            Console.ReadKey();

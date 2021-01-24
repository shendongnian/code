            static void CalculateAge()
            {
                Console.WriteLine("Enter your year of birth ");
                Console.Write("> ");
                int date = Convert.ToInt32(Console.ReadLine());
                int age = (2018 - date);
                Console.Write("You are " + (age));
                Console.ReadLine();
            }

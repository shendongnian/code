            string pass = "";
            Console.Write("Enter your password: ");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    pass = pass.Remove(pass.Length - 1);
                    Console.Write("\b \b");
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine("The Password You entered is : " + pass);

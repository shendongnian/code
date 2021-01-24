    do
            {
                counter += 1;
    
                if (guess_number == 2)
                {
                    min = middle + 1;
                }
                else if (guess_number == 1)
                {
                    max = middle - 1;
                }
                else if (guess_number != 1 || guess_number != 2 || guess_number != 0)
                {
                    Console.WriteLine(" Please write 0, 1 or 2 " + name);
                }
                middle = (min + max) / 2;
                Console.WriteLine("Is your guess " + middle + " ?\nIf it's your guess then write (0) please!\nIf it's too high then write (1) please!\nIf it's too low then write (2) please!");
                input = Console.ReadLine();
                guess_number = Convert.ToInt32(input);
                Console.WriteLine(counter + " times I tried for finding your number ");
            } while (guess_number != 0);
    
       

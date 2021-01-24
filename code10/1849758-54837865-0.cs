            Console.WriteLine("Please enter a string of letters");
            string input = Console.ReadLine();
            char[] input_array = input.ToArray();
            Console.WriteLine("please enter letters you would like removed");
            string removedLetters =Console.ReadLine();
            char[] remove_array = removedLetters.ToArray();
            char[] leftover_array = input_array.Except(remove_array).ToArray();
            Console.WriteLine(new string(leftover_array));

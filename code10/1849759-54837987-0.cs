            Console.WriteLine("Please enter a string of letters");
            string input = Console.ReadLine();
            List<char> input_array = input.ToList();
            Console.WriteLine("please enter letters you would like removed");
            string removedLetters = Console.ReadLine();
            char[] remove_array = removedLetters.ToArray();
            for (int k = 0; k < remove_array.Count(); k++)
            { input_array.RemoveAll(r=>r== remove_array[k]);  }
            Console.WriteLine(new string(input_array.ToArray()));

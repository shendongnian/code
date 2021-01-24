    switch (input.Key)
    {
        case ConsoleKey.NumPad1:
            string r = rnd.Next(stringEmployeeArray.Count()).ToString();
            int x = rnd.Next(intCarsSoldArray.Count());
            Console.WriteLine("This weeks employee of the week is(string)stringEmployeeArray[r] + (int)intCarsSoldArray[x]");
            break;
        case ConsoleKey.NumPad2:
            int sum = intCarsSoldArray.Sum();
            Console.WriteLine("Total cars sold for this week is(intCarsSoldArray.Sum)");
            break;
        case ConsoleKey.NumPad2:
            break;
    }

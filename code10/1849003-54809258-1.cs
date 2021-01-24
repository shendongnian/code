    using System;
    using System.Collections.Generic;
    HashSet<int> numbers = new HashSet<int>();
    for (int i = 0; i < 10; i++)
    {
        // Start with a random number
        //
        int value = random.Next(1,15);
        // Check whether you already have that number
        // Keep trying until you get a unique
        //
        while (numbers.Contains(value)) {
            value = random.Next(1,15);
        }
        // Add the unique number to the set
        numbers.Add(value);
    }
    foreach (int i in numbers)
    {
        Console.Write(" {0}", i);
    }

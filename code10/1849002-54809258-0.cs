    using System;
    using System.Collections.Generic;
    HashSet<int> numbers = new HashSet<int>();
    for (int i = 0; i < 10; i++)
    {           
        numbers.Add(random.Next(1, 15));
    }
    foreach (int i in numbers)
    {
        Console.Write(" {0}", i);
    }

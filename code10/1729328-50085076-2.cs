    for (int i = 0; i < zahlen2.Count; i++)
    {
        // this inserts each zahl into the given input string at position
        input = input.Insert(position, zahlen2[i].ToString());
    }
    Console.WriteLine(input);

    for (int x = 0; x < table.Length; x++)
    {
        for (int y = 0; y < table.Length; y += 2)
        {
            Console.WriteLine("{0} {1}", table[x, y], table[x, y + 1]);
        }
    }

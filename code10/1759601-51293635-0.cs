    Int64 Total = 0;
    int First = 0;
    int Second = 10000;   
    while (First <= Second)
    {
        Total += 5000 + (250 * First);
        Console.WriteLine(Total);
        First++;
    }
    Console.ReadKey();

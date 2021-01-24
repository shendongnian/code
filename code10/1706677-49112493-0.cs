    Console.Write("Enter n: ");
    int n;
    if (Int32.TryParse(Console.ReadLine(), out n))
    {
        int[] table1 = new int[n];
        Random rnd = new Random();
        //put n randon numbers into table1
        Console.Write("Table1 -> ");
        for (int i = 0; i<n; i++)
        {
            table1[i] = rnd.Next(-100, 100);
            Console.Write(table1[i] + " ");
        }
        Console.WriteLine();
        //foreach number in table1, add two to table2
        int[] table2 = new int[n * 2];
        Console.Write("Table2 -> ");
        for (int i = 0; i<n; ++i)
        {
            table2[i] = table1[i];
            table2[i + 1] = table1[i];
            Console.Write(table2[i] + " ");
            Console.Write(table2[i + 1] + " ");
        }
        Console.ReadKey();
    }

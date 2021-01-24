    int[,] mas = new int[9, 9];
    Random rand = new Random();
    for (int i = 0; i < mas.GetLength(0); i++)
    {
        for (int k = 0; k < mas.GetLength(1); k++)
        {
            mas[i, k] = rand.Next(0, 9);
            Console.Write(mas[i, k] + " ");
        }
    
        Console.WriteLine();
    }

    int sampleSize = 2;
    int[,] data = {
        {1, 2, 3, 4 },
        {5, 6, 7, 8 },
        {9, 10, 11, 12 },
        {13, 14, 15, 16 }
    };
    
    //assume input data is a perfect square as per your example
    int max = (int)Math.Sqrt(data.Length);
    
    List<int[,]> samples = new List<int[,]>();
    
    int startX = 0;
    while (startX + sampleSize <= max)
    {
        int startY = 0;
        while (startY + sampleSize <= max)
        {
            int[,] sample = new int[sampleSize, sampleSize];
            for (int x = 0; x < sampleSize;x++)
            {
                for (int y = 0; y < sampleSize; y++)
                {
                    sample[x, y] = data[x + startX, y + startY];
                }
            }
            samples.Add(sample);
            startY += sampleSize;
        }
        startX += sampleSize;
    }
    
    //for output testing
    foreach (int[,] sample in samples)
    {
        Console.WriteLine(sample[0, 0].ToString().PadLeft(2) + " | " + sample[0, 1]);
        Console.WriteLine(" -----  ");
        Console.WriteLine(sample[1, 0].ToString().PadLeft(2) + " | " + sample[1, 1]);
        Console.WriteLine();
        Console.WriteLine();
    
    }
    Console.ReadLine();

    int rowLength = arr.GetLength(0);
    int colLength = arr.GetLength(1);
    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            Console.Write(string.Format("{0} ", arr[i, j]));
        }
        Console.WriteLine();
    }

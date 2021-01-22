    private static void TestArray()
    {
        const int rows = 5000;
        const int columns = 9000;
        DateTime t1 = System.DateTime.Now;
        double[][] arr = new double[rows][];
        for (int i = 0; i < rows; i++)
            arr[i] = new double[columns];
        DateTime t2 = System.DateTime.Now;
    
        Console.WriteLine(t2 - t1);
    
        t1 = System.DateTime.Now;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                arr[i][j] = i * j;
        t2 = System.DateTime.Now;
    
        Console.WriteLine(t2 - t1);
       
    }

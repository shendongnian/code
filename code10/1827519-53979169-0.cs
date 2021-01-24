    int[][] newtab = new int[4][];
    newtab[0] = new int[4] { 0,0,0,0 };
    newtab[1] = new int[4] { 0, 0, 0, 0 };
    newtab[2] = new int[4] { 0, 0, 0, 0 };
    newtab[3] = new int[4] { 0, 0, 0, 0 };
    
    
    for (int i = 0; i < newtab.Length; i++)
    {
        for (int j = 0; j < newtab[i].Length; j++)
        {
            Console.Write(newtab[i][j]);
        }
        Console.WriteLine();
    }

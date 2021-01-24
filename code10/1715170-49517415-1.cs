    static void Main(string[] args)
    {
        Console.WriteLine($"Cell 3,1 neighbors 3,2? {IsNeighbor(3, 1, 3, 2)}");
        Console.WriteLine($"Cell 3,1 neighbors 5,4? {IsNeighbor(3, 1, 5, 4)}");
        string[,] tiles = new string[7, 7];
        Console.WriteLine($"\nFor a grid of {tiles.GetLength(0)} x {tiles.GetLength(1)} cells:\n");
        var neighbors = GetNeighborIndexes(tiles, 0, 0);
        foreach(var n in neighbors)
        {
            Console.WriteLine($"Cell neighboring 0,0: {n[0]},{n[1]}");
        }
        Console.ReadKey();
        bool IsNeighbor(int selectedX, int selectedY, int testX, int testY)
        {
            if(testX == selectedX && testY == selectedY) return false;
            return (testX >= selectedX -1 && testX <= selectedX + 1) && (testY >= selectedY - 1 && testY <= selectedY + 1);
        }
        List<int[]> GetNeighborIndexes(object[,] data, int selectedX, int selectedY)
        {
            int xmax = data.GetLength(0) - 1;
            int ymax = data.GetLength(1) - 1;
            List<int[]> result = new List<int[]>(8);
            for(int yoffset = -1; yoffset < 2; yoffset++)
            {
                int y = selectedY + yoffset;
                if(y > -1 && y <= ymax)
                {
                    for(int xoffset = -1; xoffset < 2; xoffset++)
                    {
                        if(xoffset == 0 && yoffset == 0) continue; // selected pos
                        int x = selectedX + xoffset;
                        if(x < 0 || x > xmax) continue;
                        result.Add(new int[] { x, y });
                    }
                }
            }
            return result;
        }
    }

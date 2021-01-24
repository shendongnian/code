    public static void Main(string[] args)
    {
        int width;
        int height;
        Console.WriteLine("Please enter the width of the array");
        width = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter the height of the array");
        height = Convert.ToInt32(Console.ReadLine());
        
        int[,] grid = new int [width,height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Console.WriteLine(grid[x, y]);
            }
        }
    }

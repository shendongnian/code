    class Program
    {
        Random rng = new Random();
        ...
        public static Boolean[,] initialiseMap()
        {
            Boolean[,] map = new Boolean[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double random = rng.NextDouble();
                    if (random < chanceToStartAlive)
                    {
                        map[x,y] = true;
                    }
                }
            }
            return map;
        }
        ...
    }

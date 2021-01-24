    int[,] items = new int[2, 2];
    int width = items.GetUpperBound(0) + 1;
    int height = items.GetUpperBound(1) + 1;
    for (int x = 0; x < width; ++x)
    {
        for (int y = 0; y < height; ++y)
        {
            string input;
            int inputValue;
            do
            {
                Console.WriteLine($"Please input value for ({x},{y}): ");
            }
            while (!int.TryParse(input = Console.ReadLine(), out inputValue));
            items[x, y] = inputValue;
        }
    }

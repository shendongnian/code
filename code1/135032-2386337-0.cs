    StreamReader sr = new StreamReader("input.txt");
    string line;
    char[] lineCh;
    char current;
    int x, y;
    bool north, east, south, west;
    x = y = 0;
    while ((line = sr.ReadLine()) != null)
    {
        foreach (var gs in GetGridSquares(line))
        {
            // grid[x, y] = gs;
        }
         Console.WriteLine(line);
         y++;
     }

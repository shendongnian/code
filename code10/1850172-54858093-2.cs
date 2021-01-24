    List<int[]> points = new List<int[]>();            
    string topLeftCornerX = "100";
    string topLeftCornerY = "10";
    for (int i = int.Parse(topLeftCornerX); i < int.Parse(topLeftCornerX) + 6; i++)
    {
        for (int j = int.Parse(topLeftCornerY); j > int.Parse(topLeftCornerY) - 6; j--)
        {
            int[] point = new int[2];
            point[0] = i;
            point[1] = j;
            points.Add(point);
        }
    }
    foreach (int[] item in points)
    {
        Console.WriteLine(item[0]);
        Console.WriteLine(item[1]);
    }
    Console.ReadLine();

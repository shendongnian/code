    List<Point> points = new List<Point>();            
    string topLeftCornerX = "100";
    string topLeftCornerY = "10";
    for (int i = int.Parse(topLeftCornerX); i < int.Parse(topLeftCornerX) + 6; i++)
    {
        for (int j = int.Parse(topLeftCornerY); j > int.Parse(topLeftCornerY) - 6; j--)
        {
            points.Add(new Point(i, j);
        }
    }
    foreach (Point item in points)
    {
        Console.WriteLine($"[{item.X}, {item.Y}]");
    }
    Console.ReadLine();

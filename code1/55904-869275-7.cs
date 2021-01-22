    void Main()
    {
        Point p1 = new Point(0, 0);
        Method2(p1, 5);
        Console.WriteLine(p1.ToString());
    }
    
    void SetX(Point p2, int value)
    {
        p2.X = value;
    }

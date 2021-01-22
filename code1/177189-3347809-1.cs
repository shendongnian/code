    static void Main(string[] args)
    {
        Vector3D a, b;
        a = new Vector3D(0, 5, 10);
        b = new Vector3D(0, 0, 0);
        b = a.Clone();
        a.x = 10;
        Console.WriteLine("vector a=" + a.ToString());
        Console.WriteLine("vector b=" + b.ToString());
        Console.ReadKey();
    }

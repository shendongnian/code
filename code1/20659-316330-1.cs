    int depth = 0;
    do
    {
        path = Path.GetDirectoryName(path);
        Console.WriteLine(path);
        ++depth;
    } while (!string.IsNullOrEmpty(path));
    Console.WriteLine("Depth = " + depth.ToString());

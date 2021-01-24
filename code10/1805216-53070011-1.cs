    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
        string triangle = GetFloydsTriangle(num);
        Console.WriteLine(triangle);
        Console.Write("\nDone! Press any key to exit...");
        Console.ReadKey();
    }

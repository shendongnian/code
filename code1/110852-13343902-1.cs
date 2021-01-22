    static void Main(string[] args)
    {
        string s = "223232-1.jpg";
        Console.WriteLine(s.Split('-').First());
        s = "443-2.jpg";
        Console.WriteLine(s.Split('-').First());
        s = "34443553-5.jpg";
        Console.WriteLine(s.Split('-').First());
        Console.ReadKey();
    }

    static int _yes = 0;
    static int _no = 0;
    
    static void Main(string[] args)
    {
        for (int i = 0; i < 1000000; i++)
        {
            double x = 1;
            double y = 2;
            if (y - 1 == x)
            {
                _yes++;
            }
            else
            {
                _no++;
            }
        }
        Console.WriteLine("Yes: " + _yes);
        Console.WriteLine("No: " + _no);
        Console.Read();
    }

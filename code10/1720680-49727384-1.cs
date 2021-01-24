    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(SmallestDivisor(n));
    }
            
    public static int SmallestDivisor(int n, int d=2)
    {
        if (n % d == 0)
            return d;
        return SmallestDivisor(n, ++d);
    }

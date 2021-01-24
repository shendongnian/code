    public static int i = 5;
    static void Main(string[] args)
    {
        name(5);
    }
    public static int name(int i)
    {
        if (i < 0)
        {
            return i;
        }
        
        if (i > 0)
        {
            Console.WriteLine(i);
            i--;
        }
        return i;
    }

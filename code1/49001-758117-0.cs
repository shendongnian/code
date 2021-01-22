    public static void Main(string[] args)
    {
        using (new Timer(methodThatExecutesEveryTenMinutes, null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10)))
        {
            while (true)
            {
                if (Console.ReadLine() == "quit")
                {
                    break;
                }
            }
        }
    }
    private static void methodThatExecutesEveryTenMinutes(object state)
    {
        // some code that runs every ten minutes
    }

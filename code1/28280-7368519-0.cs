    static void Main(string[] args)
    {
        bool? fred = null;
        if (!fred)
        {
            Console.WriteLine("you should not see this");
        }
        else
        {
            Console.WriteLine("Microsoft fixed this in 4.5!!!");
        }
    }

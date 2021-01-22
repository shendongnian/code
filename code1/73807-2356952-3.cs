    public static void Main(string[] args)
    {
        bool flag = false;
        try
        {
            if (DateTime.Now < DateTime.MaxValue)
            {
                flag = Environment.NewLine != "\t";
            }
            else
            {
                return;
            }
        }
        finally
        {
            if (flag)
            {
                Console.WriteLine("Test Me Deeply");
            }
        }
        Console.WriteLine("MMM. Cheese is yummy.");
    }
 
 

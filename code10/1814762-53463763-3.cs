    public static void Main(string[] args)
    {
    
        for (int i = 0; i < 10; i++)
        {
            int j = i;
            Task.TaskFactory.StartNew(() =>
            {
                Thread.Sleep(10); //Give a little time for the for loop to complete.
                Console.WriteLine("i: " + i + " j: " + j);
            }
        });
        Console.ReadLine();
    }

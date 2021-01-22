    static void Main(string[] args)
    {
        Thread t = new Thread(() =>
        {
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        });
        t.Start();
        Console.ReadKey();
    }

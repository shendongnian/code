    static void Main(string[] args)
    {
        int x = 0;
        try
        {
            int divide = 12 / x;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            int divide = 12 / x;
        }
        finally
        {
            Console.WriteLine("I am finally block");
        }
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        int x = 0;
        try
        {
            int divide = 12 / x;
        }
        catch (Exception ex)
        {
            try
            {
                Console.WriteLine(ex.Message);
                int divide = 12 / x;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
            }
        }
        finally
        {
            Console.WriteLine("I am finally block");
        }
        Console.ReadLine();
    }

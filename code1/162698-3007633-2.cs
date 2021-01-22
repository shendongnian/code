    static void Main(string[] args)
    {
        try
        {
            new Test().s();
        }
        catch (ArgumentException x)
        {
            Console.WriteLine("ArgumentException caught!");
        }
        catch (Exception ex) 
        { 
            Console.WriteLine("Exception caught!");
        }
        Console.WriteLine("I am some code that's running after the exception!");
    }

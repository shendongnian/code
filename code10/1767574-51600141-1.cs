    try
    {
        int divide = 12 / x;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Oops. Division by Zero.");
    }
    finally
    {
        Console.WriteLine("I am finally block");
    }

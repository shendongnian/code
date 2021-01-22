    int SafeDivision(int x, int y)
    {
        try
        {
            return (x / y);
        }
        catch (System.DivideByZeroException dbz)
        {
            System.Console.WriteLine("Division by zero attempted!");
            return 0;
        }
    }

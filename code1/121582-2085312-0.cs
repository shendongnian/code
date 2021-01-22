    try
    {
        try
        {
            throw new ArgumentException("Innermost exception");
        }
        catch (Exception ex)
        {
            throw new Exception("Wrapper 1",ex);
        }
    }
    catch (Exception ex)
    {
        // Writes out the ArgumentException details
        Console.WriteLine(ex.GetBaseException().ToString());
    }

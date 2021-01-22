    try
    {
        var broken = int.Parse("null");
    }
    catch (Exception ex1)
    {
        System.Diagnostics.Trace.WriteLine(ex1.ToString());
    }
    
    try
    {
        try
        {
            var broken = int.Parse("null");
        }
        catch (Exception)
        {
            throw;
        }
    }
    catch (Exception ex2)
    {
        System.Diagnostics.Trace.WriteLine(ex2.ToString());
    }
    
    try
    {
        try
        {
            var broken = int.Parse("null");
        }
        catch (Exception ex3)
        {
            throw ex3;
        }
    }
    catch (Exception ex4)
    {
        System.Diagnostics.Trace.WriteLine(ex4.ToString());
    }

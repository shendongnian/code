    var rs = RunspaceFactory.CreateRunspace();
    rs.Open();
    var ps = rs.CreatePipeline();
    ps.Commands.AddScript("Get-Member");
    ps.Commands.AddScript("ps");
    
    try
    {
        var result = ps.Invoke();
    
        if (ps.HadErrors)
        {
            var errors = ps.Error.ReadToEnd();
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
    
        foreach (var r in result)
        {
            Console.WriteLine(r);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        ps.Stop();
    }

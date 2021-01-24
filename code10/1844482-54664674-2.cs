    ServiceReference1.ServiceClient client2 = new ServiceReference1.ServiceClient();
    try
    {
        var res = client2.SayHelloAsync();
        Console.WriteLine(res.Result);
    
    }
    catch (Exception)
    {
        throw;
    }

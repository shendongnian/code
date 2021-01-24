    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
    ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
    try
    {
        var result = client.SayHello();
        Console.WriteLine(result);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }

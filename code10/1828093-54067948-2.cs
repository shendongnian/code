    ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
                try
                {
                    Console.WriteLine(client.SayHello());
                }
                catch (Exception)
                {
    
                    throw;
                }

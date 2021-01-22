    var test = "Hello";
    new Thread(new ThreadStart(() =>
    {
        try
        {
            //Staff to do
            Console.WriteLine(test);
        }
        catch (Exception ex)
        {
            throw;
        }
    })).Start();

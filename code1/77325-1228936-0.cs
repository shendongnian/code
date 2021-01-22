    try
    {
        using (var response = sendRequest.GetResponse())
        {
        }
    }
    catch (Exception ex) {
        Console.WriteLine(ex.ToString()); // Or however you want to display it
        throw;
    }

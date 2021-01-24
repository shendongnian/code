    try
    {
        var response = await client.PostAsync(tokenEndPoint, content);
        //read the response body as a string here
        string token = await response.Content.ReadAsStringAsync();
        Console.WriteLine(response);
    }
    catch (WebException e)
    {
        Console.WriteLine("catch");
        Console.WriteLine(e);
        throw;
    }

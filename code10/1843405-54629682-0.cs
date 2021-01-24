    var response = RestClient.Execute<AuthenticateResponse>(request);
    
    if (response.ErrorException == null)
    {
        Console.WriteLine($"API TEST : {response.Content}");
    }
    else
    {
        Console.WriteLine($"API TEST : FAIL {response.ErrorException.Message}");
    }

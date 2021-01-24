    public void CreateAuthorizationTest()
    {
        var response = CreateAuthorization("https://example.com", "username", "password");
        var result = response.Result;
        var o = result.Content.ReadAsStringAsync();
    
        if (result.IsSuccessStatusCode)
        {
            //do some thing if success
            // you can do deserialization what ever
            Console.WriteLine(o);
        }
        else
        {
            //do some thing if error
            Console.WriteLine(o);
        }
        //etc.
    }

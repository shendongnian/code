    // start "tracking" sets/gets to this property
    VeracrossMock.SetupProperty(_ => _.Authorization);
    var byteArray = Encoding.ASCII.GetBytes("username:password1234");
    var authorization = new AuthenticationHeaderValue("Basic",  Convert.ToBase64String(byteArray));
    //set value
    VeracrossMock.Object.Authorization = authorization;

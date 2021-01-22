    var parameters = new Dictionary<string, string>();
    parameters.Add("name", "My Name Here");
    string responseText;
    var responseStatusCode = CallWebService("http://localhost/TestWebService.asmx", 
                                            "http://tempuri.org/", 
                                            "SayHello", 
                                            parameters, 
                                            out responseText);

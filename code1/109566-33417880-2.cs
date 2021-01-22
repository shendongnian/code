	// Create a RestClient passing in a custom authenticator and base url
    var client = new RestClient
        {
            Authenticator = new AfdAuthenticator("YOUR SERIAL", "YOUR PASSWORD", "YOUR USERID"),
            BaseUrl = new UriBuilder("http", "pce.afd.co.uk").Uri
        };
	// Create a RestRequest using the AFD service endpoint and setting the Method to GET
	var request = new RestRequest("afddata.pce", Method.GET);
	// Add the required AFD query string parameters
	request.AddQueryParameter("Data", "Address");
	request.AddQueryParameter("Task", "FastFind");
	request.AddQueryParameter("Fields", "Simple");
	request.AddQueryParameter("Lookup", "BD1 3RA");
	    // Execute the request expecting an AfdPostcodeEverywhere returned 
    var response = client.Execute<AfdPostcodeEverywhere>(request);
    // Check that RestSharp got a response
    if (response.StatusCode != HttpStatusCode.OK)
    {
        throw new Exception(response.StatusDescription);
    }
    // Check that RestSharp was able to process the response
    if (response.ResponseStatus != ResponseStatus.Completed)
    {
        throw new Exception(response.ErrorMessage, response.ErrorException);
    }
    var afdPostcodeEverywhere = response.Data;
    // Check that AFD returned data
    if (afdPostcodeEverywhere.Result < 0)
    {
        throw new Exception(afdPostcodeEverywhere.ErrorText);
    }
    // Process the results
    var addresses = afdPostcodeEverywhere.Items;

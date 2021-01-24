    log.Info("C# HTTP trigger function processed a request.");
	
    // Parsing query parameters
    string name = req.Query["name"];
	log.Info("name = " + name);
	
	string numberOfTerms = req.Query["numberOfTerms"];
	log.Info("numberOfTerms = " + numberOfTerms);
	// Validating the parameters received
	if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(numberOfTerms))
	{
	    return new BadRequestObjectResult("Please pass a name and the number of digits on the query string."); 
	}
	int termsToShow;
	try
	{
		 termsToShow = Int32.Parse(numberOfTerms);
	}
	 catch (FormatException e)
	{
	    return new BadRequestObjectResult("The numberOfTerms parameter must be an integer!"); 
	}
	if (termsToShow < 0 || termsToShow > 100) {
		 return new BadRequestObjectResult("Please pass a numberOfTerms parameter between 0 and 100."); 
	}
	// Building the response
	string incompleteResponse = "Hello, " + name + ", you requested the first " + numberOfTerms + " terms of the Fibonacci series. Here they are: ";
	string completeResponse = GenerateFibonacciTerms(incompleteResponse, termsToShow);
	var response = new OkObjectResult(completeResponse); 
	// Returning the HTTP response with the string we created
	log.Info("response = " + response);
	return response;

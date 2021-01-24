	static void Main()
	{
		var client = new RestClient("http://example.com");
		var request = new RestRequest("resource/{id}", Method.POST);
        //response is always IRestResponse if you call Execute()
		var response = client.Execute(request);
		PrintResponseStuff(response);
	}
    public static void PrintResponseStuff(IRestResponse response)
    {
        Console.WriteLine(response.StatusCode);
        Console.WriteLine(response.StatusDescription);
        Console.WriteLine(response.IsSuccessful);
        Console.WriteLine(response.Content);
        Console.WriteLine(response.ContentType);
    }

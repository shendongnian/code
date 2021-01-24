	static readonly string awsAccessKey = "access key here";
	static readonly string awsSecretKey = "secret key here";
	private static BasicAWSCredentials awsCredentials = new BasicAWSCredentials(awsAccessKey, awsSecretKey);
	private static AmazonLambdaConfig lambdaConfig = new AmazonLambdaConfig() { RegionEndpoint = RegionEndpoint.USEast1 };
	private static AmazonLambdaClient lambdaClient = new AmazonLambdaClient(awsCredentials, lambdaConfig);
	public async Task<string> GetLambdaResponse(string myData)
	{
		var lambdaRequest = new InvokeRequest
		{
			FunctionName = "mylambdafunction",
			Payload = myData
		};
		var response = await lambdaClient.InvokeAsync(lambdaRequest);
		if (response != null)
		{
			using (var sr = new StreamReader(response.Payload))
			{
				return await sr.ReadToEndAsync();
			}
		}
		return string.Empty;		
	}

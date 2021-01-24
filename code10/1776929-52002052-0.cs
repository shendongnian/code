            var data = new string[] { "this movie was extremely good .", "the plot was very boring ." };
			var serializedData = JsonConvert.SerializeObject(data);
			var credentials = new Amazon.Runtime.BasicAWSCredentials("","");
			var awsClient = new AmazonSageMakerRuntimeClient(credentials, RegionEndpoint.EUCentral1);
			var request = new Amazon.SageMakerRuntime.Model.InvokeEndpointRequest
			{
				EndpointName = "endpoint",
				ContentType = "application/json",
				Body = new MemoryStream(Encoding.ASCII.GetBytes(serializedData)),
			};
			var response = awsClient.InvokeEndpoint(request);
			var predictions = Encoding.UTF8.GetString(response.Body.ToArray());

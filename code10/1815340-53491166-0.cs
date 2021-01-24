    // if using an access key
    var httpConnection = new AwsHttpConnection("us-east-1", new StaticCredentialsProvider(new AwsCredentials
    {
    	AccessKey = "My AWS access key",
    	SecretKey = "My AWS secret key",
    }));
    
    // if using app.config, environment variables, or roles
    var httpConnection = new AwsHttpConnection("us-east-1");
    
    var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    var config = new ConnectionSettings(pool, httpConnection);
    var client = new ElasticClient(config);

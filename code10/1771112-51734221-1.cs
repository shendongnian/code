    public class DynamoDbClientAccessor : IDynamoDbClientAccessor
    {
    	private readonly DynamoDbClientAccessorSettings settings;
    	
    	public DynamoDbClientAccessor(IOptions<DynamoDbClientAccessorSettings> options)
    	{
    		settings = options?.Value ?? throw new ArgumentNullException(nameof(options));
    	}
    	
    	public DynamoDBContext GetContext()
    	{
    		// You have the option to alter this if you don't
    		// want to create a new context each time. 
    		// Have a private variable at the top of this class
    		// of type DynamoDBContext. If that variable is not null,
    		// return the value. If it is null, create a new value,
    		// set the variable, and return it.
    		
    		var awsCredentials = Helper.AwsCredentials(settings.Id, settings.Password);
    		var awsdbClient = Helper.DbClient(awsCredentials, settings.Region);
    		var awsContext = Helper.DynamoDbContext(awsdbClient);
    		
    		return awsContext;
    	}
    }

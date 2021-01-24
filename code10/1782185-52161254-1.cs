    class NewService : IService<ExtendedConfiguration>
    {
    	public int Calculate(int userId, ExtendedConfiguration configuration)
    	{
    		string accessHereTheExtendedVersion = configuration.Filter;
    		return (configuration.Min + configuration.Max) / 2;
    	}
    }

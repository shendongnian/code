    class MyDbConfiguration : DbConfiguration
    {
    	public MyDbConfiguration()
    	{
    		AddInterceptor(new EFHacks.MyDbCommandTreeInterceptor());
    	}
    }

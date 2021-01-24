    public class ConnectionFactory
    {
    	private Lazy<ConnectionMultiplexer> _cnn1 { get; set; }
    	private Lazy<ConnectionMultiplexer> _cnn2 { get; set;}
    	public ConnectionFactory(string cnn1, string cnn2)
    	{
    		_cnn1 = new Lazy<UserQuery.ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(cnn1));
    		_cnn2 = new Lazy<UserQuery.ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(cnn2));
    	}
    	public ConnectionMultiplexer GetConnection1()
    	{
    		return _cnn1.Value;
    	}
    	public ConnectionMultiplexer GetConnection2()
    	{
    		return _cnn2.Value;
    	}
    }

	public interface IClient
	{
		string Name { get; }
	}
	
	public class Client : IClient
	{
		public string Name { get; set; }
	}
         ...
	public IList<T> GetClientsByListofID<T>( IList<int> ids )
             where T : class, IClient
	{
		var clients = new List<T>();
		var client = new Client { Name = "bob" } as T;
		
		clients.Add( client );
		
		return clients;
	}

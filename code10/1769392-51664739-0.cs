	public class ServerCollection : IServerCollection
	{
		private IList<Server> _myListOfServersObjects = new ObservableCollection<Server>();
		public IList<Server> ObservableServers {get => _myListOfServersObjects;}
	}

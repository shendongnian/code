	public sealed class Client1 : ClientBase, IClient
	{
		public Client1([KeyFilter("WebProvider")] IProvider provider) : base(provider) { 
		}
	}

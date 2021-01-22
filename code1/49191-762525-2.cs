	class Program
	{
		static void Main(string[] args)
		{
			IServerInterface proxy = CreateProxy();
			proxy.DoSomething(new Data());
		}
	}

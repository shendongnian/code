	class Program
	{
		static void Main(string[] args)
		{
			IServerInterface proxy = CreateProxy();
			ResultData result = proxy.DoSomething(new Data());
		}
	}

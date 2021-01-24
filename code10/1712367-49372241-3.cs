	class ProviderService
	{
		public TResult Interact<TInput,TResult> (Func<TInput, TResult> lambdaCode)  where TInput : class, new()
		{
			var x = new TInput();
            Initialize(x); //or whatever
			return lambdaCode(x);
		}
	}
	public static void Test()
	{
		var providerService = new ProviderService();
		var isInit = providerService.Interact((Foobar x) => x.FoobarInit());
	}

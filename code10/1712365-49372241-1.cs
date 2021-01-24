	class ProviderService
	{
		public TResult Interact<TResult> (Func<Foobar, TResult> lambdaCode) 
		{
			var x = new Foobar();
            Initialize(x); //or whatever
			return lambdaCode(x);
		}
	}

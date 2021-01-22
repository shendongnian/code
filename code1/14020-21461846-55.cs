	[PSerializable]
	public class RetryOnExceptionAttribute : MethodInterceptionAspect
	{
		public RetryOnExceptionAttribute()
		{
			this.MaxRetries = 3;
		}
		public int MaxRetries { get; set; }
		public override void OnInvoke(MethodInterceptionArgs args)
		{
			int retriesCounter = 0;
			while (true)
			{
				try
				{
					args.Proceed();
					return;
				}
				catch (Exception e)
				{
					retriesCounter++;
					if (retriesCounter > this.MaxRetries) throw;
					Console.WriteLine(
						"Exception during attempt {0} of calling method {1}.{2}: {3}",
						retriesCounter, args.Method.DeclaringType, args.Method.Name, e.Message);
				}
			}
		}
	}

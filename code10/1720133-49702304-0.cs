	static class ExtensionMethods
	{
		public static async Task Run<T>(this T This) where T : IRunnable
		{
			await This.Execute();
		}
		public static async Task Run<T>(this Task<T> This) where T : IRunnable
		{
            ////Await the task and pass it through to the original method
			await (await This).Execute();
		}
	}

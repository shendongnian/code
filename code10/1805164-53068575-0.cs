    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace CancellationTokenPOC
    {
	class Program
	{
		public static async Task Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			TokenPOC t = new TokenPOC();
			var longRunningTask = Task.Factory.StartNew(async () =>
			{
				for (int i = 0; i < 10; i++)
				{
					Console.WriteLine(i);
					t.token.ThrowIfCancellationRequested();
					await Task.Delay(10000);
				}
			});
			Console.ReadKey();
			t.source.Cancel();
			await Task.Delay(1000);
			Console.WriteLine("finishing");
		}
	}
	class TokenPOC
	{
		public CancellationTokenSource source = new CancellationTokenSource();
		public CancellationToken token;
		public TokenPOC()
		{
			token = source.Token;
		}
	}
    }

		static void Main(string[] args)
		{
			var lc = new LevelContext();
			Console.WriteLine(lc.CurrentLevel);
			using (lc.NewLevel())
				Console.WriteLine(lc.CurrentLevel);
			Console.WriteLine(lc.CurrentLevel);
		}

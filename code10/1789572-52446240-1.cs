	class Needer
	{
		public INeeded obj { get; set; }
		public IAnotherNeeded obj2 { get; set; }
		public Needer(INeeded param1, IAnotherNeeded param2)
		{
			obj = param1;
			obj2 = param2;
		}
	}

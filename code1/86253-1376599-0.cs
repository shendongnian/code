		public struct Something
		{
			public readonly int Number;
			public readonly string Name;
			public Something(int num, string name) { this.Number = num; this.Name = name; }
		}
		public readonly Something[] GlobalCollection = new Something[] 
		{
			new Something(1, "One"),
			new Something(2, "Two"),
		};

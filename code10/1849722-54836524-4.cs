	public class ObjA
	{ 
		public string Name { get; set; }
	}
	public class ObjB
	{
		public string Name { get; set; }
	}
	public class ClassA
	{
		public Dictionary<string, ObjA> Vals { get; set; } = new Dictionary<string, ObjA>{
			{"a", new ObjA(){ Name = "A", } },
			{"b", new ObjA(){ Name = "B", } },
			{"c", new ObjA(){ Name = "C", } },
			{"d", new ObjA(){ Name = "D", } },
		};
	}
	public class ClassB
	{
		public Dictionary<string, ObjB> Vals { get; set; } = new Dictionary<string, ObjB>{
			{"a", new ObjB(){ Name = "A", } },
			{"b", new ObjB(){ Name = "B", } },
			{"c", new ObjB(){ Name = "C", } },
			{"d", new ObjB(){ Name = "D", } },
		};
	}

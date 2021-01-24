	public class SecondImplementation : FirstImplementation
	{
		public SecondImplementation(param1, param2, param3)
			: base(param1, param2)
		{
		}
		
		public override Bar Foo()
		{
			// do something with param1, param2 and param3, perhaps by calling base.Foo().
		}
	}

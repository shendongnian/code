	internal class Test
	{
		public Test()
		{
			Source = 15;
		}
		public int? Source { get; private set; }
		public int? Destination { get; private set; }
	}
	var testType = typeof( Test );
	var sourceProperty = testType.GetProperty( "Source" );
	var destProperty = testType.GetProperty( "Destination" );
	var test = new Test();
	destProperty.SetValue( test, sourceProperty.GetValue( test, null ), null );

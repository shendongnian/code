    	interface ITest
	{
		// Other stuff
		string Prop { get; }
	}
	// Implements other stuff
	abstract class ATest : ITest
	{
		abstract public string Prop { get; }
	}
	// This implementation of ITest needs the user to set the value of Prop
	class BTest : ATest
	{
		string foo = "BTest";
		public override string Prop
		{
			get { return foo; }
			set { foo = value; } // Not allowed. 'BTest.Prop.set': cannot override because 'ATest.Prop' does not have an overridable set accessor
		}
	}
	// This implementation of ITest generates the value for Prop itself
	class CTest : ATest
	{
		string foo = "CTest";
		public override string Prop
		{
			get { return foo; }
			// set; // Not needed
		}
	}

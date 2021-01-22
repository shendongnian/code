	class Program
	{
		static void Main( string[] args )
		{
			Bob bob = new Bob();
			Jill jill = new Jill();
			Marko marko = new Marko();
			for( int i = 0; i < 1000000; i++ )
			{
				Test( bob );
				Test( jill );
				Test( marko );
			}
		}
		public static void Test( ChildNode childNode )
		{	
			TestSwitch( childNode );
			TestIfElse( childNode );
		}
		private static void TestIfElse( ChildNode childNode )
		{
			if( childNode is Bob ){}
			else if( childNode is Jill ){}
			else if( childNode is Marko ){}
		}
		private static void TestSwitch( ChildNode childNode )
		{
			switch( childNode.Name )
			{
				case "Bob":
					break;
				case "Jill":
					break;
				case "Marko":
					break;
			}
		}
	}
	class ChildNode	{ public string Name { get; set; } }
	class Bob : ChildNode {	public Bob(){ this.Name = "Bob"; }}
	class Jill : ChildNode{public Jill(){this.Name = "Jill";}}
	class Marko : ChildNode{public Marko(){this.Name = "Marko";}}

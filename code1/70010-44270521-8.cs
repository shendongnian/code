	// example java-style enum:
	public sealed class Example : Enumeration<Example, Example.Const>, IEnumerationMarker
    {
	    /* add any custom data you want: */
        private int fooNumber;
		private string barText;
		
        private Example (int woo, string hoo) /* no need to call base ctor! */
		{
		    fooNumber = woo;
			barText = hoo;
		}
		/* add any properties and methods you want: */
        public int MagicNumber { get { return fooNumber; } }
		
		public string MyText() { return barText; }
		/// <summary> Declare your enum constants here - and document them </summary>
        public static readonly Example Foo = new Example (23, "foo");
        public static readonly Example Bar = new Example (42, "woof");
        public static readonly Example Bas = new Example (123, "meow");
		// this is the only drawback - you have to mirror your declaration here:
        public enum Const
        {
            Foo,
            Bar,
            Bas,
        }
    }

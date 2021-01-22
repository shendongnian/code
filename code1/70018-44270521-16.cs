	// example java-style enum:
	public sealed class Example : Enumeration<Example, Example.Const>, IEnumerationMarker
    {
        private Example () {}
		/// <summary> Declare your enum constants here - and document them. </summary>
        public static readonly Example Foo = new Example ();
        public static readonly Example Bar = new Example ();
        public static readonly Example Bas = new Example ();
		// mirror your declaration here:
        public enum Const
        {
            Foo,
            Bar,
            Bas,
        }
    }

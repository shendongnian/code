    public sealed class Colors : StringEnum
    {
        public static Colors Red { get { return new Catalog("Red"); } }
		public static Colors Yellow { get { return new Catalog("Yellow"); } }
		public static Colors White { get { return new Catalog("White"); } }
        private Colors(string value) : base(value) { }
    }

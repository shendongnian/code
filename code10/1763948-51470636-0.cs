    public sealed class MyClass
    {
        private static readonly Dictionary<string, MyClass> Cache;
        static MyClass()
        {
            Cache = new Dictionary<string, MyClass>()
            {
                { "one", new MyClass("one") { OtherRuntimeData = "other runtime data 1" } },
                { "two", new MyClass("two") { OtherRuntimeData = "other runtime data 2" } },
            };
        }
		// XmlSerializer required parameterless constructor.
		private MyClass() => throw new NotImplementedException();
        private MyClass(string name) => this.Name = name;
		public string Name { get; }
        public string OtherRuntimeData { get; set; }
        public static MyClass Parse(string from) => Cache[from];
		
		public static IEnumerable<MyClass> Instances => Cache.Values;
    }

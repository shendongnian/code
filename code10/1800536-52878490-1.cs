    public class Foo
	{
		public Foo()
		{
			ObjectListStringConverter.Objects = new List<object>(){ new Bar("Bar0"), new Bar("Bar1"), new Bar("Bar2") };
		}
		[DisplayName(nameof(SelectedBar)),
		 Browsable(true),
		 TypeConverter(typeof(ObjectListStringConverter))]
		public Bar SelectedBar { get; set; } = null;
	}
	public class Bar
	{
		public string Name;
		public Bar(string name) { Name = name; }
		public override string ToString()
		{
			return Name;
		}
	}

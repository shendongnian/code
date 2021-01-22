	public class Foo
	{
		public string Bar;
		public string Baz;
	}
	public bool HasDuplicates(IEnumerable<Foo> foos)
	{
		var strings = foos
			.SelectMany(f => new[] { f.Bar, f.Baz })
			.ToList();
		return strings.Distinct().Count() != strings.Count;
	}

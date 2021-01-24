	public class Foo2 
    {
		public ICollection<Bar> Bars { get; }
		
		public Foo2() : this(Enumerable.Empty<Bar>()) { }
		
		public Foo2(IEnumerable<Bar> bars)
		{
			Bars = new List<Bar>(bars);
		}
	}

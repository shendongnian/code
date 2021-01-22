	[ComVisible(true)]
	public interface IFoo
	{
		string Bar { get; set; }
	}
	[ComVisible(true)]
	public class Foo : IFoo
	{
		public string Bar { get; set; }
	}

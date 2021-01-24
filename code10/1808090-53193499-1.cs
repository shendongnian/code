    public interface IParent
	{
		string HelloWorld { get; }
	}
	public class Parent : IParent
	{
		protected virtual string World { get; }
		public string HelloWorld
		{
			get
			{
				return "Hello " + World;
			}
		}
	}
	public class Children : Parent
	{
		protected override string World { get; } = "World";
	}

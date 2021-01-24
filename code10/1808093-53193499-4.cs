	public interface IParent
	{
		string HelloWorld { get; }
	}
	public class Parent : IParent
	{
		private readonly string world;
		public Parent(string world)
		{
			this.world = world;
		}
		public string HelloWorld
        {
            get
            {
                return "Hello " + world;
            }
        }
	}
	public class Children : Parent
	{
		public Children(string world) : base(world)
		{
		}
	}

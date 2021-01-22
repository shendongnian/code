    [AttributeUsage( AttributeTargets.ReturnValue )]
	public class CuriosityAttribute:Attribute
	{
	}
	public class Bar
	{
		[return: Curiosity]
		public Bar ReturnANewBar()
		{
			return new Bar();
		}
	}

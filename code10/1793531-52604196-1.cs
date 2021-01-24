    public class Toaster : IStuff
	{
		public int ValueOfMyThing { get; set; }
		public IStuff Copy()
		{
			return new Toaster { ValueOfMyThing = ValueOfMyThing };
		}
	}
    // ...

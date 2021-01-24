	interface IShelter<out AnimalType>
	{
		AnimalType Contents { get; }
	}
	class Shelter<AnimalType> : IShelter<AnimalType>
	{
		public Shelter(AnimalType animal)
		{
		}
		public void SetContents(AnimalType newContents)
		{
			Contents = newContents;
		}
		public AnimalType Contents { get; set; }
	}
	public class Usage
	{
		public static void Main()
		{
			var catshelter = new Shelter<Cat>(new Cat());
			catshelter.SetContents(new Cat());
			catshelter.SetContents(new Lion()); // Is disallowed by the compiler
		}
	}

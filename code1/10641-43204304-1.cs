	class Program
	{
		static void Main(string[] args)
		{
			fish shark = new fish();
			shark.size = "large";
			shark.lfType = "Fish";
			shark.name = "Jaws";
			Console.WriteLine(shark.name);
			human me = new human();
			me.legs = 2;
			me.lfType = "Human";
			me.name = "Paul";
			Console.WriteLine(me.name);
		}
	}
    
	public abstract class lifeform
	{
		public string lfType { get; set; }
	}
	public abstract class mammal : lifeform 
	{
		public int legs { get; set; }
	}
    
	public class human : mammal
	{
		public string name { get; set; }
	}
    
	public class aquatic : lifeform
	{
		public string size { get; set; }
	}
    
	public class fish : aquatic
	{
		public string name { get; set; }
	}

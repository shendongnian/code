	class Program
	{
		static void Main(string[] args)
		{
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

	public class ItemBase
	{	
		public ItemBase()
		{
            //When instantiating ItemBase the value of Name is "Base"
			Name = "Base"; 
		}
		public string Name { get; set; }
	}
	
	public class Hammer : ItemBase
	{
		public Hammer()
		{
            //When instantiating Hammer the value of Name is "Hammer"
			Name = "Hammer";
		}
	}

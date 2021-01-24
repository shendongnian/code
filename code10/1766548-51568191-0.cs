	void Main()
	{
		Mapper.Initialize(cfg=>
		{
			cfg.RecognizeDestinationPostfixes("k__BackingFieldField");	
		});
		Mapper.AssertConfigurationIsValid();
		
		Mapper.Map<ItemDto>(new Item { Name = "Name" }).Dump();
	}
	public class Item
	{
		public string Name{get;set;}
	}
	public class ItemDto
	{
		public string Namek__BackingFieldField{get;set;}
	}

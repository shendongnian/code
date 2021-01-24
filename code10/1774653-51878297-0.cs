	public void WriteStrings() 
	{
		var items = GetItems();
		var resultingStrings = from parent in items.Where(x => x.ParentId == 0)
			join child in items on parent.Id equals child.ParentId
			join grandChild in items on child.Id equals grandChild.ParentId
			select $"Parent{parent.Id}:Child{child.Id}:GrandChild{grandChild.Id}";
		foreach(var item in resultingStrings)
			Console.WriteLine(item);
	}
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ParentId { get; set; }
	}
	public List<Item> GetItems() {
		var list = new List<Item>();
		list.Add(new Item { Id = 1, Name = "Parent1", ParentId = 0 });
		list.Add(new Item { Id = 2, Name = "Child1", ParentId = 1 });
		list.Add(new Item { Id = 3, Name = "Child2", ParentId = 1 });
		list.Add(new Item { Id = 4, Name = "GrandChild1", ParentId = 2 });
		list.Add(new Item { Id = 5, Name = "GrandChild2", ParentId = 2 });
		list.Add(new Item { Id = 6, Name = "GrandChild3", ParentId = 3 });
		list.Add(new Item { Id = 7, Name = "GrandChild4", ParentId = 3 });
		list.Add(new Item { Id = 8, Name = "Parent2", ParentId = 0 });
		list.Add(new Item { Id = 9, Name = "Child1", ParentId = 8 });
		list.Add(new Item { Id = 10, Name = "Child2", ParentId = 8 });
		list.Add(new Item { Id = 11, Name = "GrandChild1", ParentId = 9 });
		list.Add(new Item { Id = 12, Name = "GrandChild2", ParentId = 9 });
		list.Add(new Item { Id = 13, Name = "GrandChild3", ParentId = 10 });
		list.Add(new Item { Id = 14, Name = "GrandChild4", ParentId = 10 });
		return list;
	}

	class Item { }
	class Issuer: IDisposable
	{
		Queue<Item> queue = new Queue<Item>();
		List<Item> deliveredItems = new List<Item>();
		public Item GetItem()
		{
			Item item = queue.Dequeue();
			deliveredItems.Add(item);
			return item;
		}
		public void SubmitItem(Item item)
		{
			deliveredItems.Remove(item);
			
			// do some operation here
		}
		public void Dispose()
		{
			foreach (Item item in deliveredItems)
			{
				SubmitItem(item);
			}
		}
	}

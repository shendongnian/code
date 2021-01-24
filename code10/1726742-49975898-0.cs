   	class GroceryItem
	{
		public string name;
		public double price;
		public PurchasedItem pItem
		{
			get;
			set;
		}
		public GroceryItem(string a, double b)
		{
			name = a;
			price = b;
		}
		internal class PurchasedItem
		{
			GroceryItem item;
			public PurchasedItem(GroceryItem gItem)
			{
				item = new GroceryItem(gItem.name, gItem.price);
			}
			public int quantity;
			public double FindCost()
			{
				return item.price * this.quantity * 1.10;
			}
			class FreshItem
			{
				public double weight;
			}
		}
	}

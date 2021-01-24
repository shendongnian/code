		void Main()
		{
			var nums = new[]{
					new { inv = 1, lineitems =new [] {new { qty = 1, sku = "a" }, new { qty = 2, sku = "b" }}},
					new { inv = 2, lineitems =new [] { new { qty = 3, sku = "c" }, new { qty = 4, sku = "d" }}},
					new { inv = 3, lineitems =new [] { new { qty = 5, sku = "e" }, new { qty = 5, sku = "f" }}}
			};
			
			// How do I pass in the reference to the newly being created Invoice below to the Item constructor?
			
			var invoices = nums.Select(i => 
				new Invoice(i.inv, i.lineitems.Select(l => 
					new Item(l.qty, l.sku )
				).ToArray()
			));
		
			invoices.Dump();
		}
		
		public class Invoice 
		{
			public int Number { get; }
			public Item[] Items { get; }
			public Invoice(int number, Item[] items) {
				Number = number;
				Items = items;
				foreach(var item in Items) item.AttachParent(this);
			}
		}
		
		public class Item 
		{
			public Invoice Parent { get; private set; }
			public int Qty { get; }
			public string SKU { get; }
			public Item(int qty, string sku) {
				Qty = qty;
				SKU = sku;
			}
			
			public void AttachParent(Invoice parent) {
				if(Parent!=null) throw new InvalidOperationException("Class is immutable after parent has already been set, cannot change parent.");
				Parent = parent;
			}
		}

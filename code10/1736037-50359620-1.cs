    public class Invoice
    {
    	public int Number { get; }
    	public IReadOnlyList<Item> Items { get; }
    	public Invoice(int number, IEnumerable<Func<Invoice,Item>> items)
    	{
    		Number = number;
    		Items = items
              .Select(x => x(this))
              .ToList().AsReadOnly();
    	}
    }   
    /* usage */
    var invoices = nums.Select(i =>
			new Invoice(i.inv, i.lineitems.Select(l => 
                (Func<Invoice,Item>)(parent => new Item(l.qty, l.sku, parent))))
		).ToList();

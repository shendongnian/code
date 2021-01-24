    public class Invoice
    {
    	public int Number { get; }
    	public IReadOnlyList<Item> Items { get; }
    	public Invoice(int number, IEnumerable<Item> itemsWithoutParent)
    	{
    		Number = number;
    		Items = itemsWithoutParent
               .Select(x => new Item(x.Qty, x.SKU, this))
               .ToList().AsReadOnly();
    	}
    }

    public class Customer
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<Match> Matches { get; set; }
    }
    
    public class Inventory
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<Match> Matches { get; set; }
    }
    
    public class Match
    {
    	public int CustomerId { get; set; }
    	public Customer Custmer { get; set; }
    	public int InventoryId { get; set; }
    	public Inventory Inventory { get; set; }
    	public decimal MonthlyPayment { get; set; }
    }

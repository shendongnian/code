    public class Customer : IComparable<Customer>
    {
    	public string First { get; set; }
    	public string Middle { get; set; }
    	public string Last { get; set; }
    	
    	public Customer(string first, string middle, string last)
    	{
    		First = first;
    		Middle = middle;
    		Last = last;
    	}
    	
    	public int CompareTo(Customer p)
    	{
    		return this.First.CompareTo(p.First);
    	}
    }

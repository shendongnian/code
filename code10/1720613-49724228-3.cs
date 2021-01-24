    public class MiddleNameComparer : IComparer<Customer>
    {
    	public int Compare(Customer x, Customer y)
    	{
    		return x.Middle.CompareTo(y.Middle);
    	}
    }

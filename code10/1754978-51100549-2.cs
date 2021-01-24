    public static class MyExtensions 
    {
    	public static void AddWithFire<T>(this List<T> list, T item)
    	{
    		 list.Add(item);
    
    		 if(item is Transaction)
    		 {
    			// Call Your method that takes DateTime
    			YourMethod(((Transaction)item).TransactionDate);
    		 }
    	}
    }
    
    public class Transaction
    {
    	public DateTime TransactionDate {get; set;}
    }

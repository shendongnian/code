    void Main()
    {
    	List<ReturnItem> items = new List<ReturnItem>();
    	items.Add(new ReturnItem() 
    			  { 
    			  		ID = 1, 
    					Columns = new List<object>() 
    					{
    						DateTime.Now,
    						"donkey"
    					}
    			   });
    
    	items.Add(new ReturnItem() 
    			  { 
    			  		ID = 2, 
    					Columns = new List<object>() 
    					{
    						DateTime.Now.AddHours(3),
    						"baboon"
    					}
    			   });
    
    	items.Add(new ReturnItem() 
    			  { 
    			  		ID = 3, 
    					Columns = new List<object>() 
    					{
    						DateTime.Now.AddHours(2),
    						"antelope"
    					}
    			   });
    			   
    
    	IEnumerable<ReturnItem> sortedByDate =
    		items.OrderBy(x => x.Columns[0]);
    		
    	IEnumerable<ReturnItem> sortedByAnimal =
    		items.OrderBy(x => x.Columns[1]);
        IEnumerable<ReturnItem> filteredByBaboon =
                items.Where(x => x.Columns[1] == "baboon");
    }
    
    
    public class ReturnItem
    {
    	public int ID;
    	public List<object> Columns;
    }

    public class Master
    {
    	public int ID;
    }
    
    public class Detail
    {
    	public int ID;
    	public int Count;
    }
    
    public static void AddMissingDetails(IEnumerable<Master> masters, List<Detail> details)
    {
    	AddMissingDetails(masters, details, x => new Detail
    		{
    			ID = x,
    			Count = 0
    		});
    }
    
    public static void AddMissingDetails(IEnumerable<Master> masters, List<Detail> details, Func<int, Detail> createDefault)
    {
    	details.AddRange(
    		masters
    			.Select(x => x.ID)
    			.Except(details.Select(x => x.ID).Distinct())
    			.Select(createDefault));
    }

    public class PwActivityTypeCollection : IListable<PwActivityType>
    {
    	public List<PwActivityType> user;
    	public List<PwActivityType> system;
    
    	public List<PwActivityType> AsList()
    	{
    		return user.Concat(system).ToList();
    	}
    }

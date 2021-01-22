    public abstract class CashUpdateQuery
    {
    	public CashUpdateQuery(int cashId)
    	{
    		this.CashId = cashId;
    	}
    	
    	protected int CashId { get; private set; }
    	
    	public abstract void SetConnectionProperties(OurCustomDbConnection conn);
    }

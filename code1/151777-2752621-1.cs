    public partial class YourDataContext
    {
    	public override void SubmitChanges(ConflictMode failureMode)
    	{
    		ChangeSet changes = GetChangeSet();
    		
    		foreach (var entity in changes.Inserts())
    		{
    		}
    
    		// you could do the same with updates and deletes
    		
    		base.SubmitChanges(failureMode);
    	}
    }

    public partial class YourDataContext
    {
    	public override void SubmitChanges(ConflictMode failureMode)
    	{
    		ChangeSet changes = GetChangeSet();
    		
    		foreach (var entity in changes.Inserts())
    		{
    		}
    
    		// you could the same with udates and deletes
    		
    		base.SubmitChanges(failureMode);
    	}
    }

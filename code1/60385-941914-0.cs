    using System.ComponentModel;
    
    [DataObject]
    public class MyODS
    {
    	[DataObjectMethod(DataObjectMethodType.Update)]
    	public void UpdateNames(string First)
    	{
    		UpdateNames(First, null)
    	}
    	
    	[DataObjectMethod(DataObjectMethodType.Update)]
    	public void UpdateNames(string First, string Last)
    	{
    		//Do the update
    	}
    }

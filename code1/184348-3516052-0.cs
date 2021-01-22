    public class ObjectCreateResult
    {
    	public ObjectCreateStatus CreateStatus { get; set; }
    	public Guid CreateGuid { get; set; }
    }
    
    
    public ObjectCreateResult AddSchedule(Schedule schedule)
    {
    	ObjectCreateResult result = new ObjectCreateResult();
    
    	var client = new Services.ConfigurationClient();
    	try
    	{
    		ConfigurationMessage cMsg =
    			client.ConfigService.AddSchedule(
    				this.ControllerBase.SessionVariables.Credentials,
    				schedule
    				);
    		if (cMsg.Result == ConfigurationResultEnum.Success)
    		{
    			result.CreateStatus = ObjectCreateStatus.Success;
    			result.CreateGuid = Guid.NewGuid(); // Set your actual Guid here
    		}
    		else
    		{
    			result.CreateStatus = ObjectCreateStatus.GeneralError;
    			result.CreateGuid = Guid.Empty;
    		}
    			              
    	}
    	finally
    	{
    		client.Close();
    	}
    
    	return result;
    }

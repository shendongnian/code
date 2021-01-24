    class Presentation
    {
    	void StartUp()
    	{
    		// Use SqlServerDataProvider to store the audit events on SQL
    		Audit.Core.Configuration.Setup()
    			.UseSqlServer(_ => _
    				.ConnectionString("...")
    				.TableName("Event")
    				.IdColumnName("EventId")
    				.JsonColumnName("Data"));
    				
    		// Add a custom action to have a custom field 
    		Audit.Core.Configuration.AddOnCreatedAction(scope =>
    		{
    			scope.SetCustomField("OwinUser", OwinContextHelper.CurrentApplicationUser);
    		});
    	}
    }

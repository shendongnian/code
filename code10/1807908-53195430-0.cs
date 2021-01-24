	public void Execute(IServiceProvider serviceProvider)
	{
		IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
		ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
		IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
		IOrganizationService service = factory.CreateOrganizationService(context.UserId);
		if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity && context.InputParameters != null )
		{
			Entity entity = (Entity)context.InputParameters["Target"];
			if (entity.LogicalName == "account")
			{
				try
				{
					UpdateInsertAccountCopy(entity);
				}
				catch (Exception ex)
				{
					throw new InvalidPluginExecutionException(ex.Message);
				}
			}
		}
	}
		
	public void UpdateInsertAccountCopy(Entity account)
	{	
		//whether it is a create or an update, set the fields on a new entity object
		var copy = new Entity("new_accountcopy");
		copy["new_name"] = account.GetAttributeValue<string>("name");
		copy["new_phone"] = account.GetAttributeValue<string>("telephone1");
		copy["new_fax"] = account.GetAttributeValue<string>("fax");
		copy["new_website"] = account.GetAttributeValue<string>("websiteurl");
		
		//if there is an existing AccountCopy
		if(account.GetAttributeValue<EntityReference>("new_accountcopyid") != null
		{
			//set the Id on the new copy entity object
			copy.Id = account.GetAttributeValue<EntityReference>("new_accountcopyid").Id;
			//then update it
			service.Update(copy);
		}
		//otherwise, create the AccountCopy
		else
		{
			service.Create(copy);
		}			
	}					
    

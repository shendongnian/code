	private List<Entity> getRecords()
	{
		using (var context = new Microsoft.Xrm.Sdk.Client.OrganizationServiceContext(svc))
		{
			var result = from e in organizationServiceContext.CreateQuery("new_entity")
					     where e.GetAttributeValue<string>("new_field") == "my value"
					     select e;
			return result.Take(100).ToList();
		}
	}

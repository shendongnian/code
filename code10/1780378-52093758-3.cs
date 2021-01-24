	foreach (JObject singScopeRes in result)
	{
		var permission = new Rbac.BusinessEntities.V2.Resource();
		permission.Id = new Guid(singScopeRes["id"].ToString());
		permission.Model = new Rbac.BusinessEntities.V2.Models()
		{
			Name = (singScopeRes["model"]["name"]).ToObject<List<string>>()
		};
	 }

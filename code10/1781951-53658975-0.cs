    projContext.Load(projContext.CustomFields);
    projContext.ExecuteQuery();
    var projectCustomFieldDisplayName = "My Project Custom Field Display Name";
    var projectCustomField = projContext.CustomFields.FirstOrDefault(cf => cf.Name == projectCustomFieldDisplayName);
    object projectCustomFieldValue = "";
    var resourceCustomFieldDisplayName = "My Enterprise Resource Custom Field Display Name";
    var resourceCustomField = projContext.CustomFields.FirstOrDefault(cf => cf.Name == resourceCustomFieldDisplayName);
    
    foreach (EnterpriseResource resource in enterpriseResources)
    {
    	if (!string.IsNullOrEmpty(resource.Email))
    	{
    		var pId = Guid.Parse("a5c8801f-d505-e811-a745-b0359f8878e9");
    		var customProject = projContext.LoadQuery(projContext.Projects.Where(p => p.Id == pId).Include(
    			p => p.Id,
    			p => p.Name,
    			p => p.IncludeCustomFields,
    			p => p.IncludeCustomFields.CustomFields,
    			P => P.IncludeCustomFields.CustomFields.IncludeWithDefaultProperties(
    			lu => lu.LookupTable,
    			lu => lu.LookupEntries
    			))
    		);
    
    		projContext.ExecuteQuery();
    
    		foreach (PublishedProject pubProj in customProject)
    		{
    			var projECFs = pubProj.IncludeCustomFields.CustomFields;
    			Dictionary<string, object> ECFValues = pubProj.IncludeCustomFields.FieldValues;
    			
    			if (projectCustomField != null)
    			{
    				projectCustomFieldValue = ECFValues.Where(pair => pair.Key == projectCustomField.InternalName).FirstOrDefault().Value;
    			}
    		}
    		
    		// Update enterprise resource custom field
    		if (resourceCustomField != null)
    		{
    			resource.SetCustomFieldValue(resourceCustomField.InternalName, projectCustomFieldValue);
    			enterpriseResources.Update();
    		}
    	}
    }

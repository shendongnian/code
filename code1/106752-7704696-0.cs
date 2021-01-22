    public IDictionary<int,string> PickListValues(string entityname, string attributename)
    {
    	var req = new RetrieveAttributeRequest();
    	req.EntityLogicalName = entityname;
    	req.LogicalName = attributename;
    	req.RetrieveAsIfPublished = true;
    
    	var response = (RetrieveAttributeResponse)Service.MetaDataService.Execute(req);
    
    	var picklist = (PicklistAttributeMetadata)response.AttributeMetadata;
    
        var res = new Dictionary<int,string>();
    	foreach (var item in picklist.Options)
    	   res.Add(item.Value.Value, item.Label.UserLocLabel.Label);
        return res;
    }

    var userFacilityMapping = new Dictionary<string, string>
    {
    	["App_Inventory_LOC1_Access"] = "LOC1",
    	["App_Inventory_LOC2_Access"] = "LOC2",
    	["App_Inventory_LOC3_Access"] = "LOC3",
    };
    var userFacilities = userFacilityMapping
    	.Where(x => HttpContext.Current.User.IsInRole(x.Key))
    	.Select(x => x.Value)
    	.ToArray();
    
    items = items.Where(x => userFacilities.Contains(x.Facility));

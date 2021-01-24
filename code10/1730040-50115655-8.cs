    // using Newtonsoft.Json.Linq
    var json = new JObject(
    	new JProperty("Category", "Missile"),
    	new JProperty("Type", "LRM"),
    	new JProperty("WeaponSubType", "LRM20"),
    	new JProperty("Description",
    		new JObject(
    			new JProperty("Cost", 180000),
    			new JProperty("Rarity", 0)
    			)
    		)
    	);

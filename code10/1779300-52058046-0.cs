    //Pass in the name of the array property you want to flatten
    public string FlattenJson(string input, string arrayProperty)
    {
        //Convert it to a JObject
    	var unflattened = JsonConvert.DeserializeObject<JObject>(input);
    
        //Return a new array of items made up of the inner properties
        //of the array and the outer properties
    	var flattened = ((JArray)unflattened[arrayProperty])
    		.Select(item => new JObject(
    			unflattened.Properties().Where(p => p.Name != arrayProperty), 
    			((JObject)item).Properties()));
    
        //Convert it back to Json
    	return JsonConvert.SerializeObject(flattened);
    }

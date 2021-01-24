    var json = @"{
        ""OptionType"":{
            ""C"": [
                ""C"",
                ""Call""
            ],
            ""P"": [
                ""P"",
                ""Put""
            ]
        }
    }";
    
    var valueToCheck = "Call";
    string type = null;
    
    var ot = JObject.Parse(json);
    var objectType = ot["OptionType"];
    
    foreach (var token in objectType)
    {
    	var prop = token.ToObject<JProperty>();
    	var key = prop.Name;
    	var values = prop.Value.ToObject<List<string>>();
    	if (values.Contains(valueToCheck))
    	{
    		type = key;
    		break;
    	}
    }

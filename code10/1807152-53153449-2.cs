    public string ValidateJson(string json)
    {    
        JObject jObject = JObject.Parse(json);
    
        SampleClass model = jObject.ToObject<SampleClass>();
    
        string response = string.Empty;
    
        foreach (var i in model.data)
        {
            switch (i.Key)
            {
                case "sno":
                    if (i.Value.Type != JTokenType.String)
                        response = "SNo is not a string";
                    break;
    
                case "project_name":
                    if (i.Value.Type != JTokenType.String)
                        response = "Project name is not a string";
                    break;
    
                case "contributors":
                    if (i.Value.Type != JTokenType.Array)
                        response = "Contributors is not an array";
                    break;
    
                case "office":
                    if (i.Value.Type != JTokenType.Array)
                        response = "Office is not an array";
                    break;
            }
        }
    
        return response;
    }

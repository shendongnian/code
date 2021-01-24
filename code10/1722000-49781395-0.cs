    var inputDict = new Dictionary<string, object>();
    inputDict["device.name"] = "Machine-39FK394S";
    inputDict["device.username"] = "admin";
    inputDict["device.operating_system"] = "Windows 10";
    inputDict["something.else"] = 294;
    var outputObject = new Dictionary<string, object>();
    foreach (var kvp in inputDict)
    {
        var propertyName = kvp.Key;
        var fields = propertyName.Split('.');
        var currentDict = outputObject;
        for (int i = 0; i < fields.Length; i++)
        {
            var field = fields[i];
            if (i == fields.Length - 1)
            {
                currentDict[field] = kvp.Value;
                break;
            }
            if (!currentDict.ContainsKey(field))
            {
                currentDict[field] = ((object)new Dictionary<string, object>());
            }
                
            currentDict = currentDict[field] as Dictionary<string, object>;
        }
    }
    var json = JsonConvert.SerializeObject(outputObject, Formatting.Indented);
    Console.WriteLine("JSON: " + json);
    

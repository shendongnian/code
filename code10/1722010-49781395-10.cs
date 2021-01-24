    var inputDict = new Dictionary<string, object>();
    inputDict["device.name"] = "Machine-39FK394S";
    inputDict["device.username"] = "admin";
    inputDict["device.operating_system"] = "Windows 10";
    inputDict["something.else"] = 294;
    var outputObject = new Dictionary<string, object>();
    foreach (var kvp in inputDict)
    {
        var currentDict = outputObject;
        var depth = 0;
        var fields = kvp.Key.Split('.');
        foreach (var field in fields)
        {
            if (++depth == fields.Length)
            {
                currentDict[field] = kvp.Value;
            }
            else if (!currentDict.ContainsKey(field))
            {
                currentDict[field] = new Dictionary<string, object>();
            }
            currentDict = currentDict[field] as Dictionary<string, object>;
        }
    }
    var json = JsonConvert.SerializeObject(outputObject, Formatting.Indented);
    Console.WriteLine("JSON: " + json);
    

    // Load the content of the file as a string
    string json = File.ReadAllText(pathToJson);
    // Parse the JSON to a Newtonsoft.Json.Linq.JObject
    JObject obj = JObject.Parse(json);
    // Add the property
    obj["pageTitle"] = "Base Client";
    // Convert back to a JSON string
    string newJson = obj.ToString();
    // Save the string back to the file
    File.WriteAllText(pathToJson, newJson);

    var JSONobj = JObject.Parse(json);
    
    foreach (JToken child in JSONobj.Children())
    {
        var prop = child as JProperty; 
        var propertyName = prop.Name; // this will give you the name of the property
        if (propertyName == "DidWeCharge")
        {
           // Do something here?
        }
        if (propertyName == "DidWeHold")
        {
           // Do something here?
        }
    }
 

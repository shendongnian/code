    var JSONobj = JObject.Parse(json);
    
    foreach (JToken child in JSONobj.Children())
    {
        var prop = child as JProperty; 
        var propertyName = prop.Name; // this will give you the name of the property
        if (propertyName == "DidWeCharge")
        {
           
           var value = prop.Value; // Do something here with value?
        }
        if (propertyName == "DidWeHold")
        {
           var value = prop.Value; // Do something here with value?
        }
        
        var propertyType = prop.Value.Type; // this return the type as a JTokenType enum.
    }
 

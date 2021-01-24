    var dynamicObject = JObject.Parse(yourstring);
    var list = new List<Lookup>();
    //now you have a dynamic object containing an array.
    //this should be doable with linq as well.
    //note, the type is dynamic
    foreach (dynamic thing in dynamicObject )
    {
       list.Add(new Lookup()
       {
          id = thing.fields.id,
          SerialNumber = thing.fields.SerialNumber
       });
    }

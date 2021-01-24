    string jsonString = "{\"Year\":\"2019\",\"Model\":\"Corvette Stingray\",\"UnitType\":\"Asset\"}";
    var resultUnit = JsonConvert.DeserializeObject<Unit>(jsonString);
    if (resultUnit.IsValid())
    {
        // This works, do the right thing. When the type matters access resultUnit.UnitType
    }
    else
    {
       //Throw an exception, really badly formed or an Unknown type
    }

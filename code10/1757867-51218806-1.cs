    var json = "{ \"name\": \"John\",  \"age\": 55, \"fooBoo\": 0}";
    
    JObject obj = JObject.Parse(json);
            
    dynamic foo = new ExpandoObject();
    var bar = (IDictionary<string, object>) foo;
    foreach (JProperty property in obj.Properties())
    {
        var janky = property.Name.Substring(0, 1).ToUpperInvariant() + property.Name.Substring(1);
        bar.Add(janky, property.Value);
    }
    Console.WriteLine($"{foo.Name} , {foo.Age}, {foo.FooBoo}");

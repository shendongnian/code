    JObject jObject = JObject.Parse(json);
    
    var result = jObject["Configurations"]["Tr984"]["Operations"].Children().Children().ToList().Select(x => x.ToObject<JObject>()).Properties().Select(y => new { Key = y.Name, Value = y.Value });
    
    foreach (var i in result)
    {
        //comboBox1.Items.Add(i.Value);  
        Console.WriteLine(i.Key + ": " + i.Value);
    }
    Console.ReadLine();

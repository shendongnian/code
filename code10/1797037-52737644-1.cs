    JObject jObject = JObject.Parse(json);
    var result = jObject["Configurations"]["Tr984"]["Operations"].Children().Children().ToList();
    foreach (JToken token in result)
    {
        JObject jObject1 = token.ToObject<JObject>();
        foreach (JProperty property in jObject1.Properties())
        {
            //comboBox1.Items.Add(property.Value);  
            Console.WriteLine(property.Name + ": " + property.Value);
        }
    }
    Console.ReadLine();

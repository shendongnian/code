    // As an example for your input data.....
    string json =  "{\"fields\":[\"/field1/{field1value}/field2/{field2value}/field3/{field3value}\",\"/field1/{field1value}/field2/{field2value}/field3/{field3value}\"]}";
    // Json.NET JObject.Parse
    var lines = JObject.Parse(json);
    // Remove comment with LinqPad 
    // lines.Dump();
    // Not really needed to explicitly use the Properties method...
    foreach (var x in lines.Properties())
    {
        // Remove comment with LinqPad 
        // x.Dump();
        foreach (var k in x.Value)
        {
            // Remove comment with LinqPad 
            // k.Dump();
            string dataLine = k.Value<string>();
            Console.WriteLine(dataLine);
        }
    }

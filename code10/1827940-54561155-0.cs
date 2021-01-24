    var form = JsonConvert.DeserializeObject<List<object>>(comingData.ToString());
    foreach (var item in form)
    {
        var cSharpClass = JsonConvert.DeserializeObject<dynamic>(item.ToString());
    
        foreach (JProperty item2 in cSharpClass)
        {
            Console.WriteLine(item2.Name);
            Console.WriteLine(item2.Value);
        }
    }

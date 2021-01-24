    Dictionary<string, string> dict = cjob["results"]
        .Children<JObject>()
        .Select(result => result.SelectToken("metadata.categories").Children<JProperty>()
                                .Join(result.SelectToken("data.categories").Children<JProperty>(),
                                      metaCat => metaCat.Name,
                                      dataCat => dataCat.Name,
                                      (metaCat, dataCat) => new
                                      {
                                          Name = (string)metaCat.Value["name"],
                                          Value = (string)dataCat.Value
                                      }
                                )
        )
        .SelectMany(a => a)
        .ToDictionary(a => a.Name, a => a.Value);
    foreach (var kvp in dict)
    {
        Console.WriteLine(kvp.Key + ": " + kvp.Value);
    }

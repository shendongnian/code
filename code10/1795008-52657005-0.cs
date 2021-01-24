    var dict = cjob["results"]
        .Children<JObject>()
        .Select(result => result.SelectToken("metadata.categories").Children<JProperty>()
                                .Join(result.SelectToken("data.categories").Children<JProperty>(),
                                      metaCat => metaCat.Name,
                                      dataCat => dataCat.Name,
                                      (metaCat, dataCat) => new
                                      {
                                          Name = metaCat.Value["name"],
                                          Value = dataCat.Value
                                      }
                                )
        )
        .SelectMany(a => a)
        .ToDictionary(a => (string)a.Name, a => (string)a.Value);
    foreach (var kvp in dict)
    {
        Console.WriteLine(kvp.Key + ": " + kvp.Value);
    }

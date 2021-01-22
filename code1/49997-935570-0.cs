    using (var reader = new ResourceReader(resource))
    {
      var dictionary = reader
        .Cast<DictionaryEntry>()
        .Aggregate(new Dictionary<string, object>(), (d, e) => { d.Add(e.Key.ToString(), e.Value); return d; });
      
      Console.WriteLine(dictionary["Foo"]);
    }

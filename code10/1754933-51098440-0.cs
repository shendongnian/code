      var guid = Guid.NewGuid();
        var user =
        new Dictionary<string, object>
        {
            {
                guid.ToString(),
                new {Userid = guid, Name = "Joe"}
            }
        };
        Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));

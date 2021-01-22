    public IDictionary<string, string> Get(string typeName)
    {
        var zombieValues = root.Element(typeName).Elements();
        return zombieValues.Elements()
              .ToDictionary(
                      element => element.Name.ToString(),
                      element => element.Value);
    }

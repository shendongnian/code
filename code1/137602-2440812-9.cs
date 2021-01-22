    public IDictionary<string, string> Get(string typeName)
    {
        var zombie = root.Element(typeName);
        return zombie.Elements()
              .ToDictionary(
                      element => element.Name.ToString(),
                      element => element.Value);
    }

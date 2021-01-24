    JToken GetTokenCaseInsensitive(IEnumerable<JProperty> properties, string jsonPath) {
        var parts = jsonPath.Split('.');
        var property = properties.FirstOrDefault(p =>
            string.Equals(p.Name, parts[0], StringComparison.OrdinalIgnoreCase)
        );
        for (var i = 1; i < parts.Length && property != null && property.Value is JObject; i++) {
            var jo = property.Value as JObject;
            property = jo.Properties().FirstOrDefault(p =>
                string.Equals(p.Name, parts[i], StringComparison.OrdinalIgnoreCase)
            );
        }
        if (property != null && property.Type != JTokenType.Null) {
            return property.Value;
        }
        return null;
    }
    

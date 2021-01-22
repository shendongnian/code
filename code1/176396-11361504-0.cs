    void SortProperties(JToken token)
    {
        var obj = token as JObject;
        if (obj != null)
        {
            var props = typeof (JObject)
                .GetField("_properties",
                          BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(obj);
            var items = typeof (Collection<JToken>)
                .GetField("items", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(props);
            ArrayList.Adapter((IList) items)
                .Sort(new ComparisonComparer(
                    (x, y) =>
                    {
                        var xProp = x as JProperty;
                        var yProp = y as JProperty;
                        return xProp != null && yProp != null
                            ? string.Compare(xProp.Name, yProp.Name)
                            : 0;
                    }));
        }
        foreach (var child in token.Children())
        {
            SortProperties(child);
        }
    }

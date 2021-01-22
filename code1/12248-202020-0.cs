        public static class GhettoSerializer
        {
                // you could make this a factory method if your type
                // has a constructor that appeals to you (i.e. default 
                // parameterless constructor)
                public static void Initialize<T>(T instance, IDictionary<string, object> values)
                {
                        var props = typeof(T).GetProperties();
                        // my approach does nothing to handle rare properties with array indexers
                        var matches = props.Join(
                                values,
                                pi => pi.Name,
                                kvp => kvp.Key,
                                (property, kvp) =>
                                        new {
                                                Set = new Action<object,object,object[]>(property.SetValue), 
                                                kvp.Value
                                        }
                        );
                        foreach (var match in matches)
                                match.Set(instance, match.Value, null);
                }
                public static IDictionary<string, object> Serialize<T>(T instance)
                {
                        var props = typeof(T).GetProperties();
                        var ret = new Dictionary<string, object>();
                        foreach (var property in props)
                        {
                                if (!property.CanWrite || !property.CanRead)
                                        continue;
                                ret.Add(property.Name, property.GetValue(instance, null));
                        }
                        return ret;
                }
        }

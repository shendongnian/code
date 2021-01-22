    public static T Bind<T>(IDictionary<string, string> hash)
    {
       foreach (var item in hash)
       {
            var prop = typeof(T).GetProperty(item.Key);
            prop.SetValue(channel, Convert.ChangeType(item.Value, prop.PropertyType), new object[0]);
       }
    }

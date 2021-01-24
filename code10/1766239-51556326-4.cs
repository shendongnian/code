    public static string SerializeStaticProperties(Type type)
    {
        var properties = type.GetProperties(BindingFlags.Static | BindingFlags.Public);
        var data = new List<Property>();
        foreach (var property in properties)
        {
            data.Add(new Property
            {
                Name = property.Name,
                Type = property.PropertyType,
                Value = JsonConvert.SerializeObject(property.GetValue(null))
            });
        }
        return JsonConvert.SerializeObject(data);
    }
    public static void DeserializeStaticProperties(Type type, string json)
    {
        var data = JsonConvert.DeserializeObject<List<Property>>(json);
        foreach (var item in data)
        {
            var property = type.GetProperty(item.Name, BindingFlags.Static | BindingFlags.Public);
            if (property != null)
            {
                property.SetValue(null, JsonConvert.DeserializeObject(item.Value, item.Type));
            }
        }
    }
    public class Property
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public string Value { get; set; }
    }

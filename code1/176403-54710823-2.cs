    public class PersonWithAge : Person
    {
        public int Age { get; set; }
    }
    
    public class Person
    {
        public string Name { get; set; }
    }
    public string GetJson()
    {
        var thequeen = new PersonWithAge { Name = "Elisabeth", Age = Int32.MaxValue };
    
        var settings = new JsonSerializerSettings()
        {
            ContractResolver = new MetadataTokenContractResolver(),
        };
        return JsonConvert.SerializeObject(
            thequeen, Newtonsoft.Json.Formatting.Indented, settings
        );
    }
    public class MetadataTokenContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(
            Type type, MemberSerialization memberSerialization)
        {
            var props = type
               .GetProperties(BindingFlags.Instance
                   | BindingFlags.Public
                   | BindingFlags.NonPublic
               ).ToDictionary(k => k.Name, v =>
               {
                   // first value: declaring type
                   var classIndex = 0;
                   var t = type;
                   while (t != v.DeclaringType)
                   {
                       classIndex++;
                       t = type.BaseType;
                   }
                   return Tuple.Create(classIndex, v.MetadataToken);
               });
              
            return base.CreateProperties(type, memberSerialization)
                .OrderByDescending(p => props[p.PropertyName].Item1)
                .ThenBy(p => props[p.PropertyName].Item1)
                .ToList();
        }
    }

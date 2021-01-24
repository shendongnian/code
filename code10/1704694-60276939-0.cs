    public class WritableOptions<T> : IWritableOptions<T> where T : class, new()
    {
        private readonly IOptionsMonitor<T> _options;
        private readonly string _section;
        public WritableOptions(
            IOptionsMonitor<T> options,
            string section,
            string file)
        {
            _options = options;
            _section = section;
        }
        public T Value => _options.CurrentValue;
        public T Get(string name) => _options.Get(name);
        public void Update(Action<T> applyChanges)
        {
            var physicalPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName+ "\\appsettings.json";
            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath));
            var sectionObject = jObject.TryGetValue(_section, out JToken section) ?
                JsonConvert.DeserializeObject<T>(section.ToString()) : (Value ?? new T());
            applyChanges(sectionObject);
            jObject[_section] = JObject.Parse(JsonConvert.SerializeObject(sectionObject));
            File.SetAttributes(physicalPath, FileAttributes.Normal);
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
        }
    }

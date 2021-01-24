    public class ExampleModelConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var name = token["NameProperty"].ToString();
            PropertyBase prop = null;
            // for example, it is up to you how you
            // create an instance of PropertyBase
            switch (name)
            {
                case "string" : prop = new StringProperty();
                    break;
                case "number" : prop = new NumberProperty();
                    break;
                case "array" : prop = new ArrayProperty();
                    break;
            }
            var ex = new ExampleModel
            {
                DifferentProperty = prop
            };
            serializer.Populate(reader, ex);
            return ex;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(ExampleModel) == objectType;
        }
    }
    
    [JsonConverter(typeof(PropertyConverter))]
    class ExampleModel
    {
        public string NameProperty { get; set; }
        public string OtherProperty
        {
            get; set;
        }
        public PropertyBase DifferentProperty { get; set; }
    }
    class Program
    {
        public void Main(string[] args)
        {
            var model = JsonConvert.DeserializeObject<ExampleModel>(jsonData);
        }
    }

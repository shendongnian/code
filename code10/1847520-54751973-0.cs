    You will want to clean this up a bit. But should give you a proof of concept on how to do create your custom converter.
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public double price { get; set; }
        [JsonConverter(typeof(KeysJsonConverter))]
        public List<Ingredient> ingredients { get; set; }
    }
  
    public class RootObject
    {
        public List<Item> items { get; set; }
    }
    public class KeysJsonConverter : JsonConverter
    {      
        public KeysJsonConverter()
        {
      
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();
                o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));
                o.WriteTo(writer);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ingredientsList = new List<Ingredient>();
          
            if (reader.TokenType != JsonToken.Null)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    JToken token = JToken.Load(reader);
                    List<int> items = token.ToObject<List<int>>();
                    ingredientsList = items.Select(x => IngredientList.Ingredients.FirstOrDefault(y => y.Id == x)).ToList();
                }
            }
            return ingredientsList;
        }
        public override bool CanRead
        {
            get { return true; }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object[]);
        }
    }
    public static class IngredientList
    {
        public static List<Ingredient> Ingredients = new List<Ingredient>()
        {
            new Ingredient()
            {
                Id = 1,
                Name = "Test 1"
            },
            new Ingredient()
            {
                Id = 2,
                Name = "Test 2"
            }
        };
    }
    public class Ingredient{
        public string Name { get; set; }
        public int Id { get; set; }
    }

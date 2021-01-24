    public class RootModelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RootModel);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            RootModel model = new RootModel();
            if (token.Type == JTokenType.Array)
            {
                // we have a Version 3 or earlier model, which is just a list of people.
                model.People = token.ToObject<List<Person>>(serializer);
                model.Addresses = new List<Address>();
                return model;
            }
            else if (token.Type == JTokenType.Object)
            {
                // Check that the version is something we are expecting
                string version = (string)token["Version"];
                if (version == "4")
                {
                    // all good, so populate the current model
                    serializer.Populate(token.CreateReader(), model);
                    return model;
                }
                else
                {
                    throw new JsonException("Unexpected version: " + version);
                }
            }
            else
            {
                throw new JsonException("Unexpected token: " + token.Type);
            }
        }
        // This signals that we just want to use the default serialization for writing
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class ReferenceHandlingCustomCreationConverter<T> : JsonConverter where T : class
    {
        const string refProperty = "$ref";
        const string idProperty = "$id";
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        protected virtual T Create(Type objectType, T existingValue, JsonSerializer serializer, JObject obj)
        {
            return existingValue ?? (T)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
        }
        protected abstract void Populate(JObject obj, T value, JsonSerializer serializer);
        protected abstract void WriteProperties(JsonWriter writer, T value, JsonSerializer serializer, JsonObjectContract contract);
        public override sealed object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(objectType);
            if (!(contract is JsonObjectContract))
            {
                throw new JsonSerializationException(string.Format("Invalid non-object contract type {0}", contract));
            }
            if (!(existingValue == null || existingValue is T))
            {
                throw new JsonSerializationException(string.Format("Converter cannot read JSON with the specified existing value. {0} is required.", typeof(T)));
            }
            if (reader.MoveToContent().TokenType == JsonToken.Null)
                return null;
            var obj = JObject.Load(reader);
            var refId = (string)obj[refProperty].RemoveFromLowestPossibleParent();
            var objId = (string)obj[idProperty].RemoveFromLowestPossibleParent();
            if (refId != null)
            {
                var reference = serializer.ReferenceResolver.ResolveReference(serializer, refId);
                if (reference != null)
                    return reference;
            }
            var value = Create(objectType, (T)existingValue, serializer, obj);
            if (objId != null)
            {
                // Add the empty array into the reference table BEFORE poppulating it, to handle recursive references.
                serializer.ReferenceResolver.AddReference(serializer, objId, value);
            }
            Populate(obj, value, serializer);
            return value;
        }
        public override sealed void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(value.GetType());
            if (!(contract is JsonObjectContract))
            {
                throw new JsonSerializationException(string.Format("Invalid non-object contract type {0}", contract));
            }
            if (!(value is T))
            {
                throw new JsonSerializationException(string.Format("Converter cannot read JSON with the specified existing value. {0} is required.", typeof(T)));
            }
            writer.WriteStartObject();
            if (serializer.ReferenceResolver.IsReferenced(serializer, value))
            {
                writer.WritePropertyName(refProperty);
                writer.WriteValue(serializer.ReferenceResolver.GetReference(serializer, value));
            }
            else
            {
                writer.WritePropertyName(idProperty);
                writer.WriteValue(serializer.ReferenceResolver.GetReference(serializer, value));
                WriteProperties(writer, (T)value, serializer, (JsonObjectContract)contract);
            }
            writer.WriteEndObject();
        }
    }
    public static partial class JsonExtensions
    {
        public static JsonReader MoveToContent(this JsonReader reader)
        {
            if (reader.TokenType == JsonToken.None)
                reader.Read();
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                ;
            return reader;
        }
        public static JToken RemoveFromLowestPossibleParent(this JToken node)
        {
            if (node == null)
                return null;
            var contained = node.AncestorsAndSelf().Where(t => t.Parent is JContainer && t.Parent.Type != JTokenType.Property).FirstOrDefault();
            if (contained != null)
                contained.Remove();
            // Also detach the node from its immediate containing property -- Remove() does not do this even though it seems like it should
            if (node.Parent is JProperty)
                ((JProperty)node.Parent).Value = null;
            return node;
        }
    }

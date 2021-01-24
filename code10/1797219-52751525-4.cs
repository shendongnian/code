    public class SqlHierarchyIdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(SqlHierarchyId));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
		    string id = (string)reader.Value;
            return (id == null || id == SqlHierarchyId.Null.ToString()) ? SqlHierarchyId.Null : SqlHierarchyId.Parse(id);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }

    class DataSetConverter : JsonConverter<DataSet>
    {
        public override DataSet ReadJson(JsonReader reader, Type objectType, DataSet existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.MoveToContent().TokenType == JsonToken.Null)
                return null;
            var converter = new XmlNodeConverter { OmitRootObject = false };
            var document = (XDocument)converter.ReadJson(reader, typeof(XDocument), existingValue, serializer);
            using (var xmlReader = document.CreateReader())
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(xmlReader);
                return dataSet;
            }
        }
        public override void WriteJson(JsonWriter writer, DataSet dataSet, JsonSerializer serializer)
        {
            var document = new XDocument();
            using (var xmlWriter = document.CreateWriter())
            {
                dataSet.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
            }
            var converter = new XmlNodeConverter { OmitRootObject = false };
            converter.WriteJson(writer, document, serializer);
        }
    }
    public static partial class JsonExtensions
    {
        public static JsonReader MoveToContent(this JsonReader reader)
        {
            // Start up the reader if not already reading, and skip comments
            if (reader.TokenType == JsonToken.None)
                reader.Read();
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                {}
            return reader;
        }
    }

        public class RowConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Row[]);
            }
    
            public override bool CanWrite => false;
    
            public override bool CanRead => true;
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
    
                if (reader.TokenType == JsonToken.Null)
                {
                    return string.Empty;
                }
                else if (reader.TokenType == JsonToken.String)
                {
                    return serializer.Deserialize(reader, objectType);
                }
                else
                {
                    JObject obj = JObject.Load(reader);
                    var root = obj["root"];
                    if (root != null)
                    {
                        var rows = new List<Row>();
                        foreach (var item in root)
                        {
                            var row = item["row"];
                            var newRow = new Row();
                            foreach(var field in row)
                            {
                                // better use reflection here to convert name-value to property setter
                                if (field.Value<string>("name") == "Foo")
                                {
                                    newRow.Foo = field["value"].Value<string>();
                                }
    
                                if (field.Value<string>("name") == "Bar")
                                {
                                    newRow.Bar = field["value"].Value<string>();
                                }
                            }
    
                            rows.Add(newRow);
                        }
    
                        return rows.ToArray();
                    }
                    return null;
                }
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

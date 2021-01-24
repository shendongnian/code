        class TypeInfoConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return true;
            }
    
            public override bool CanRead
            {
                get { return false; }
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var converters = serializer.Converters.Where(x => !(x is TypeInfoConverter)).ToArray();
                JToken jToken = JToken.FromObject(value);
                JObject jObject;
                switch (jToken.Type)
                {
                    case JTokenType.Object:
                    case JTokenType.Array:
                    case JTokenType.Bytes:
                    case JTokenType.Date:
                        jObject = JObject.FromObject(new Converter(value));
                        jObject.WriteTo(writer, converters);
                        break;
                    default:
                        //jObject = JObject.FromObject(new Converter(value));
                        //jObject.WriteTo(writer);
                        jToken.WriteTo(writer);
                        break;
                }
            }
    
            class Converter
            {
                public Dictionary<string, object> _attr = new Dictionary<string, object>();
                public object value;
    
                public Converter(object value)
                {
                    this.value = value;
                    addAttributes();
                }
    
                private void addAttributes()
                {
                    Type t = value.GetType();
                    _attr["type"] = t.Name;
    
                    if (t.IsGenericType
                        && (value is IList || value is IDictionary))
                    {
                        collectionAttributes(value, _attr, t);
                    }
                    else if (t.IsEnum)
                    {
                        _attr["type"] = "enum";
                        _attr["class"] = t.Name;
                        //attributes["meaning"] = value.ToString();
                    }
                }
    
                private void collectionAttributes(object value, Dictionary<string, object> attr, Type type)
                {
    
                    Dictionary<string, object> o = new Dictionary<string, object>();
                    if (value is IDictionary && value.GetType().IsGenericType)
                    {
                        attr["type"] = "map";
                        attr["key"] = type.GetGenericArguments()[0].Name;
                        if(type.GetGenericArguments()[1].IsGenericType == true)
                        {
                            collectionAttributes(((IDictionary)value).Values, o, type.GetGenericArguments()[1]);
                            attr["value"] = o;
                        }
                        else
                        {
                            attr["value"] = type.GetGenericArguments()[1].Name;
                        }
                    }
                    else if (value is ICollection && type.IsGenericType)
                    {
                        attr["type"] = "array";
                        if (type.GetGenericArguments()[0].IsGenericType == true)
                        {
                            collectionAttributes(value, o, type.GetGenericArguments()[0]);
                            attr["value"] = o;
                        }
                        else
                        {
                            attr["of"] = type.GetGenericArguments()[0].Name;
                        }
                    }
                }
            }

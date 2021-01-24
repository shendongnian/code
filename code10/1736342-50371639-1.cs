    public class ConventionBasedConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(YOUR-OBJECT).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var daat = JObject.Load(reader);
            var yourObject = new YOUR-OBJECT();
            foreach (var prop in yourObject GetType().GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
            {
                var attr = prop.GetCustomAttributes(false).FirstOrDefault();
                if (attr != null)
                {
                    var propName = ((JsonPropertyAttribute)attr).PropertyName;
                    if (!string.IsNullOrWhiteSpace(propName))
                    {
                        //split by the delimiter, and traverse recursevly according to the path
                        var conventions = propName.Split('/');
                        object propValue = null;
                        JToken token = null;
                        for (var i = 0; i < conventions.Length; i++)
                        {
                            if (token == null)
                            {
                                token = daat[conventions[i]];
                            }
                            else {
                                token = token[conventions[i]];
                            }
                            if (token == null)
                            {
                                //silent fail: exit the loop if the specified path was not found
                                break;
                            }
                            else
                            {
                                //store the current value
                                if (token is JValue)
                                {
                                    propValue = ((JValue)token).Value;
                                }
                            }
                        }
                        if (propValue != null)
                        {
                            //workaround for numeric values being automatically created as Int64 (long) objects.
                            if (propValue is long && prop.PropertyType == typeof(Int32))
                            {
                                prop.SetValue(yourObject, Convert.ToInt32(propValue));
                            }
                            else
                            {
                                prop.SetValue(yourObject, propValue);
                            }
                        }
                    }
                }
            }
            return yourObject;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }

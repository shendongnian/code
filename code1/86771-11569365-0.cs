        private class NullPropertiesConverter : JavaScriptConverter
        {
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                var jsonExample = new Dictionary<string, object>();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    var value = prop.GetValue(obj, BindingFlags.Public, null, null, null);
                    if (value != null)
                        jsonExample.Add(prop.Name, value);
                }
                return jsonExample;
            }
            public override IEnumerable<Type> SupportedTypes
            {
                get { return GetType().Assembly.GetTypes(); }
            }
        }

    namespace Custom.Xml.Serialization
    {
        public interface IXmlDeserializationCallback
        {
            void OnXmlDeserialization(object sender);
        }
    
        public class CustomXmlSerializer : XmlSerializer
        {
            public CustomXmlSerializer(Type type) : base(type) { }
    
            public new object Deserialize(Stream stream)
            {
                var result = base.Deserialize(stream);
    
                CheckForDeserializationCallbacks(result);
    
                return result;
            }
    
            private void CheckForDeserializationCallbacks(object deserializedObject)
            {
                if (deserializedObject == null)
                    return;
    
                var deserializationCallback = deserializedObject as IXmlDeserializationCallback;
    
                if (deserializationCallback != null)
                {
                    deserializationCallback.OnXmlDeserialization(this);
                }
    
                var properties = deserializedObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
                foreach (var propertyInfo in properties)
                {
    
                    if (propertyInfo.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null)
                    {
                        var collection = propertyInfo.GetValue(deserializedObject) as IEnumerable;
    
                        if (collection != null)
                        {
                            foreach (var item in collection)
                            {
                                CheckForDeserializationCallbacks(item);
                            }
                        }
                    }
                    else
                    {
                        if (propertyInfo.GetIndexParameters().Length == 0)
                            CheckForDeserializationCallbacks(propertyInfo.GetValue(deserializedObject));
                    }
                }
            }
        }
    }

    using System.Xml.Serialization;
    namespace Custom.Xml.Serialization
    {
        public interface IXmlDeserializationCallback
        {
            void OnXmlDeserialization(object sender);
        }
        public class CustomXmlSerializer : XmlSerializer
        {
            protected override object Deserialize(XmlSerializationReader reader)
            {
                var result = base.Deserialize(reader);
            
                var deserializedCallback = result as IXmlDeserializationCallback;
                if (deserializedCallback != null)
                {
                    deserializedCallback.OnXmlDeserialization(this);
                }
                return result;
            }
        }
    }

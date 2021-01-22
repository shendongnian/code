    using System.IO;
    using System.Runtime.Serialization; // System.Runtime.Serialization.dll (.NET 3.0)
    using System.Runtime.Serialization.Json; // System.ServiceModel.Web.dll (.NET 3.5)
    using System.Text;
    namespace Serialization
    {
        public static class Helpers
        {
            /// <summary>
            /// Declare the Serializer Type you want to use.
            /// </summary>
            public enum SerializerType
            {
                Xml, // Use DataContractSerializer
                Json // Use DataContractJsonSerializer
            }
    
            public static T Deserialize<T>(string SerializedString, SerializerType UseSerializer)
            {
                // Get a Stream representation of the string.
                using (Stream s = new MemoryStream(UTF8Encoding.UTF8.GetBytes(SerializedString)))
                {
                    T item;
                    switch (UseSerializer)
                    {
                        case SerializerType.Json:
                            // Declare Serializer with the Type we're dealing with.
                            var serJson = new DataContractJsonSerializer(typeof(T));
                            // Read(Deserialize) with Serializer and cast
                            item = (T)serJson.ReadObject(s);
                            break;
                        case SerializerType.Xml:
                        default:
                            var serXml = new DataContractSerializer(typeof(T));
                            item = (T)serXml.ReadObject(s);
                            break;
                    }
                    return item;
                }
            }
    
            public static string Serialize<T>(T ObjectToSerialize, SerializerType UseSerializer)
            {
                using (MemoryStream serialiserStream = new MemoryStream())
                {
                    string serialisedString = null;
                    switch (UseSerializer)
                    {
                        case SerializerType.Json:
                            // init the Serializer with the Type to Serialize
                            DataContractJsonSerializer serJson = new DataContractJsonSerializer(typeof(T));
                            // The serializer fills the Stream with the Object's Serialized Representation.
                            serJson.WriteObject(serialiserStream, ObjectToSerialize);
                            break;
                        case SerializerType.Xml:
                        default:
                            DataContractSerializer serXml = new DataContractSerializer(typeof(T));
                            serXml.WriteObject(serialiserStream, ObjectToSerialize);
                            break;
                    }
                    // Rewind the stream to the start so we can now read it.
                    serialiserStream.Position = 0;
                    using (StreamReader sr = new StreamReader(serialiserStream))
                    {
                        // Use the StreamReader to get the serialized text out
                        serialisedString = sr.ReadToEnd();
                        sr.Close();
                    }
                    return serialisedString;
                }
            }
        }
    }

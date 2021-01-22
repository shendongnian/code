<code class="cs">
    using System;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace ObjectSerialization
    {
        public static class ObjectSerialization
        {
            // THIS: (C): https://stackoverflow.com/questions/2434534/serialize-an-object-to-string
            /// <summary>
            /// A helper to serialize an object to a string containing XML data of the object.
            /// </summary>
            /// <typeparam name="T">An object to serialize to a XML data string.</typeparam>
            /// <param name="toSerialize">A helper method for any type of object to be serialized to a XML data string.</param>
            /// <returns>A string containing XML data of the object.</returns>
            public static string SerializeObject<T>(this T toSerialize)
            {
                // create an instance of a XmlSerializer class with the typeof(T)..
                XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
    
                // using is necessary with classes which implement the IDisposable interface..
                using (StringWriter stringWriter = new StringWriter())
                {
                    // serialize a class to a StringWriter class instance..
                    xmlSerializer.Serialize(stringWriter, toSerialize); // a base class of the StringWriter instance is TextWriter..
                    return stringWriter.ToString(); // return the value..
                }
            }
    
            // THIS: (C): VPKSoft, 2018, https://www.vpksoft.net
            /// <summary>
            /// Deserializes an object which is saved to an XML data string. If the object has no instance a new object will be constructed if possible.
            /// <note type="note">An exception will occur if a null reference is called an no valid constructor of the class is available.</note>
            /// </summary>
            /// <typeparam name="T">An object to deserialize from a XML data string.</typeparam>
            /// <param name="toDeserialize">An object of which XML data to deserialize. If the object is null a a default constructor is called.</param>
            /// <param name="xmlData">A string containing a serialized XML data do deserialize.</param>
            /// <returns>An object which is deserialized from the XML data string.</returns>
            public static T DeserializeObject<T>(this T toDeserialize, string xmlData)
            {
                // if a null instance of an object called this try to create a "default" instance for it with typeof(T),
                // this will throw an exception no useful constructor is found..
                object voidInstance = toDeserialize == null ? Activator.CreateInstance(typeof(T)) : toDeserialize;
    
                // create an instance of a XmlSerializer class with the typeof(T)..
                XmlSerializer xmlSerializer = new XmlSerializer(voidInstance.GetType());
    
                // construct a StringReader class instance of the given xmlData parameter to be deserialized by the XmlSerializer class instance..
                using (StringReader stringReader = new StringReader(xmlData))
                {
                    // return the "new" object deserialized via the XmlSerializer class instance..
                    return (T)xmlSerializer.Deserialize(stringReader);
                }
            }
    
            // THIS: (C): VPKSoft, 2018, https://www.vpksoft.net
            /// <summary>
            /// Deserializes an object which is saved to an XML data string.
            /// </summary>
            /// <param name="toDeserialize">A type of an object of which XML data to deserialize.</param>
            /// <param name="xmlData">A string containing a serialized XML data do deserialize.</param>
            /// <returns>An object which is deserialized from the XML data string.</returns>
            public static object DeserializeObject(Type toDeserialize, string xmlData)
            {
                // create an instance of a XmlSerializer class with the given type toDeserialize..
                XmlSerializer xmlSerializer = new XmlSerializer(toDeserialize);
    
                // construct a StringReader class instance of the given xmlData parameter to be deserialized by the XmlSerializer class instance..
                using (StringReader stringReader = new StringReader(xmlData))
                {
                    // return the "new" object deserialized via the XmlSerializer class instance..
                    return xmlSerializer.Deserialize(stringReader);
                }
            }
        }
    }
 

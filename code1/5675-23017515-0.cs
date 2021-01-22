    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of an object that is marked with '[Serializable]' or '[DataContract]'
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            if (typeof(T).IsSerializable == true)
            {
                return CloneUsingSerializable<T>(source);
            }
            if (IsDataContract(typeof(T)) == true)
            {
                return CloneUsingDataContracts<T>(source);
            }
            throw new ArgumentException("The type must be Serializable or use DataContracts.", "source");
        }
        
        /// <summary>
        /// Perform a deep Copy of an object that is marked with '[Serializable]'
        /// </summary>
        /// <remarks>
        /// Found on http://stackoverflow.com/questions/78536/cloning-objects-in-c-sharp
        /// Uses code found on CodeProject, which allows free use in third party apps
        /// - http://www.codeproject.com/KB/tips/SerializedObjectCloner.aspx
        /// </remarks>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T CloneUsingSerializable<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
  
        /// <summary>
        /// Perform a deep Copy of an object that is marked with '[DataContract]'
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T CloneUsingDataContracts<T>(T source)
        {
            if (IsDataContract(typeof(T)) == false)
            {
                throw new ArgumentException("The type must be a data contract.", "source");
            }
            // ** Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));
            using(Stream stream = new MemoryStream())
            {
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(stream))
                {
                    dcs.WriteObject(writer, source);
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    using (XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max))
                    {
                        return (T)dcs.ReadObject(reader);
                    }
                }
            }
        }
        /// <summary>
        /// Helper function to check if a class is a [DataContract]
        /// </summary>
        /// <param name="type">The type of the object to check.</param>
        /// <returns>Boolean flag indicating if the class is a DataContract (true) or not (false) </returns>
        public static bool IsDataContract(Type type)
        {
            object[] attributes = type.GetCustomAttributes(typeof(DataContractAttribute), false);
            return attributes.Length == 1;
        }
    
    } 

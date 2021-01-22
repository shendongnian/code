    public static class Clone
    {
        public static T DeepCopyViaBinarySerialization<T>(T record)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, record);
                memoryStream.Position = 0;
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }

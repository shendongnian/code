    public static void deepCopy<T>(ref T object2Copy, ref T objectCopy)
            {
                using (var stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, object2Copy);
                    stream.Position = 0;
                    objectCopy = Serializer.Deserialize<T>(stream);
                }
    
            }

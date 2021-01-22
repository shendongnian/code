        public static Stream serialize<T>(T objectToSerialize)
        {
            MemoryStream mem = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(mem, objectToSerialize);
            return mem;
        }

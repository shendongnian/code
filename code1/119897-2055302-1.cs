        public static void Serialize(DataSet ds, Stream stream) {
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, ds);
        }
        public static DataSet Deserialize(Stream stream) {
            BinaryFormatter serializer = new BinaryFormatter();
            return (DataSet)serializer.Deserialize(stream);
        } 

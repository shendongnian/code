        public static void Serialize<T>(T obj, string path)
        {
            var writer = new XmlSerializer(typeof(T));
            using (var file = new StreamWriter(path))
            {
                writer.Serialize(file, obj);
            }
        }
        public static T Deserialize<T>(string path)
        {
            var reader = new XmlSerializer(typeof(T));
            using (var stream = new StreamReader(path))
            {
                return (T)reader.Deserialize(stream);
            }
        }
        public static void SerializeAppend<T>(T obj, string path)
        {
            var writer = new XmlSerializer(typeof(T));
            FileStream file = File.Open(path, FileMode.Append, FileAccess.Write);
            writer.Serialize(file, obj);
            file.Close();
        }

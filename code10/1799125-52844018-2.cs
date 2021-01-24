    class Demo
    {
        public double A;
        public double B;
        public void WriteFormatFile(string filename)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (FileStream fs = new FileStream(filename, FileMode.Create, System.IO.FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, this);
                    }
                }
            }
        }
        public static Demo ReadFormatFile(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, System.IO.FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
                    return (Demo)serializer.Deserialize(sr, typeof(Demo));
                }
            }
        }
    }

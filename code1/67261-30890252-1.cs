    public class FileSchoool
    {
        public static Schoool Load(string path)
        {
            var encoding = System.Text.Encoding.UTF8;
            var serializer = new XmlSerializer(typeof(Schoool));
    
            using (var stream = new StreamReader(path, encoding, false))
            {
                using (var reader = new XmlTextReader(stream))
                {
                    return serializer.Deserialize(reader) as Schoool;
                }
            }
        }
    }

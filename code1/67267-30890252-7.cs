    public class FileSchool
    {
        public static School Load(string path)
        {
            var encoding = System.Text.Encoding.UTF8;
            var serializer = new XmlSerializer(typeof(School));
    
            using (var stream = new StreamReader(path, encoding, false))
            {
                using (var reader = new XmlTextReader(stream))
                {
                    return serializer.Deserialize(reader) as School;
                }
            }
        }
    }

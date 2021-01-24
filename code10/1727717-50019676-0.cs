    public class Zoo
    {
        public string ZooName { get; set; }
        ...
    
        public static Zoo Load(string file)
        {
            using (StreamReader reader = File.OpenText(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (Zoo) serializer.Deserialize(reader, typeof(Zoo));
            }
        }
    }

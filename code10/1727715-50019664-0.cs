    public class Zoo
    {
        public string ZooName { get; set; }
        ...
    
        public static Zoo Init()
        {
            using (StreamReader reader = File.OpenText(@"C:\Areas.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var myZoo = (Zoo) serializer.Deserialize(reader, typeof(Zoo));
    			return myZoo;
            }
        }
    }

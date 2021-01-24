    Class Program
    {
        ...
        private void Initialize()
        {
            Zoo myZoo = new Zoo();
            myZoo.Load(ref myZoo);
            Console.WriteLine(myZoo.ZooName);
        }
    }
    public class Zoo
    {
        public string ZooName { get; set; }
        ...
    
        internal void Load(ref Zoo myZoo)
        {
            using (StreamReader reader = File.OpenText(@"C:\Areas.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                myZoo = (Zoo) serializer.Deserialize(reader, typeof(Zoo));
            }
        }
    }

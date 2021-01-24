    public static void Main(string[] args)
    {
        string appleName = "Apple";
        Dictionary<string, string> appleColors = new Dictionary<string, string>
        {
            { "Green", "Green" }
        };
        string lemonName = "Lemon";
        Dictionary<string, string> lemonColors = new Dictionary<string, string>
        {
            { "Green", "Yellow" }
        };
        string orangeName = "Orange";
        Dictionary<string, string> orangeColors = new Dictionary<string, string>
        {
            { "Orange", "Orange" }
        };
        var fruits = new List<Fruit>();
        Fruit apple = new Fruit(appleName, appleColors);
        Fruit lemon = new Fruit(lemonName, lemonColors);
        Fruit orange = new Fruit(orangeName, orangeColors);
        fruits.Add(apple);
        fruits.Add(lemon);
        fruits.Add(orange);
        XmlSerializer serializer = new XmlSerializer(typeof(List<Fruit>), new XmlRootAttribute("Fruits"));
        using (var stream = new FileStream("fruits.xml", FileMode.CreateNew))
        {
            using(var wr = new StreamWriter(stream))
            {
                serializer.Serialize(wr, fruits);
            }
        }
                
        Console.ReadKey();
    }
    [Serializable()]
    public class Fruit
    {
        [XmlElement(ElementName = "FruitName", Order = 1)]
        public string FruitName { get; set; }
        [XmlElement(ElementName = "Color", Order = 2)]
        public Color c = new Color();
        public Fruit()
        {
        }
        public Fruit(string fruitname, Dictionary<string, string> colorDictionary)
        {
            FruitName = fruitname;
            foreach (KeyValuePair<string, string> entry in colorDictionary)
            {
                c = new Color(entry.Key, entry.Value);
            }
        }
    }
    public class Color
    {
        [XmlElement(ElementName = "Color1", IsNullable = true)]
        public string Color1 { get; set; }
        [XmlElement(ElementName = "Color2", IsNullable = true)]
        public string Color2 { get; set; }
        [XmlAttribute("Value")]
        public string Value { get; set; }
        /// <summary>
        /// Parameterless constructor for serialization.
        /// </summary>
        public Color() { }
        /// <summary>
        /// Parameterized constructor for getting and setting values.
        /// </summary>
        /// <param name="torque"></param>
        public Color(string col1, string col2)
        {
            Color1 = col1;
            Color2 = col2;
        }
    }
}

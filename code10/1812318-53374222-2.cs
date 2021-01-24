    [XmlRoot]
    public class Root
    {
        public Root()
        {
            Objects = new List<GameObject>();
        }
        [XmlElement("GameObject")]
        public List<GameObject> Objects { get; set; }
    }
    public class GameObject
    {
        public int Property1 { get; set; }
    }
    public class SampleObject : GameObject
    {
        public int Property2 { get; set; }
    }

    [Serializable]
    public class Root
    {
        [XmlArrayItem("a", typeof(A), Namespace = "myns")]
        [XmlArrayItem("b", typeof(B))]
        public List<Base> items = new List<Base>();
    }

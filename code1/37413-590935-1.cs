    [XmlRoot("chart")]
    public class Chart
    {        
        [XmlAttributeAttribute("palette")]
        public string Palette;
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public List<Category> Categories = new List<Category>();
    }
    public class Category
    {
        [XmlAttributeAttribute("label")]
        public string Label;
    }

    [XmlRoot("Model")]
    public class Model
    {
        [XmlAttribute(AttributeName = "Content")]
        public string Content { get; set; }
        [XmlArray("Units")]
        [XmlArrayItem("Unit")]
        public List<Unit> Units { get; set; }
        [XmlArray("Modules")]
        [XmlArrayItem("Module")]
        public List<Module> Modules { get; set; }
        [XmlArray("Blocks")]
        [XmlArrayItem("Block")]
        public List<Block> Blocks { get; set; }
    }
    [XmlRoot(ElementName = "Unit")]
    public class Unit
    {
        [XmlAttribute(AttributeName = "UnitCategory")]
        public string UnitCategory { get; set; }
        [XmlAttribute(AttributeName = "Units")]
        public string Units { get; set; }
    }
    [XmlRoot(ElementName = "Module")]
    public class Module
    {
        [XmlAttribute(AttributeName = "Module")]
        public string Modul { get; set; }
        [XmlElement("Parameter")]
        public List<ModuleParameter> Parameters { get; set; }
    }
    [XmlRoot(ElementName = "Parameter")]
    public class ModuleParameter
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlElement("Enumeration")]
        public List<Enumeration> Enumerations { get; set; }
    }
    [XmlRoot(ElementName = "Enumeration")]
    public class Enumeration
    {
        [XmlAttribute(AttributeName = "Tag")]
        public string Tag { get; set; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName = "Block")]
    public class Block
    {
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "Module")]
        public string Module { get; set; }
        [XmlElement("Parameter")]
        public List<BlockParameter> Parameters { get; set; }
    }
    [XmlRoot(ElementName = "Parameter")]
    public class BlockParameter
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }

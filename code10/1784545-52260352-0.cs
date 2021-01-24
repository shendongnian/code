    using System.Xml.Serialization;
    [XmlRoot(ElementName = "Rootobject")] //defining a root element for the xml
    public class Rootobject
    {
        [XmlElement(ElementName = "recipe")] //defining the name for the serialization
        public Recipe[] recipe { get; set; }
        [XmlElement(ElementName = "recipeIngredients")]//defining the name for the serialization
        public Recipeingredient[] recipeIngredients { get; set; }
    }

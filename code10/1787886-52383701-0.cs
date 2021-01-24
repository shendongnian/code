    [Serializable]
    [XmlRoot(ElementName = "Cat")]
    public class Cat
    {
        /// <summary>
        /// Gets the cat name
        /// </summary>
        [XmlAttribute("CatName")]
        public string CatName{ get; set; }
    
        /// <summary>
        /// Gets the cat origin
        /// </summary>
        [XmlAttribute("CatOrigin")]
        public string CatOrigin{ get; set; }
    }

    [XmlRoot("Animals")]
    [XmlType("Animals")]
    public class AnimalsWrapper
    {
        [XmlElement(typeof(Bird), ElementName = "Bird")]
        [XmlElement(typeof(Cat), ElementName = "Cat")]
        public List<Animal> Animals;
    }

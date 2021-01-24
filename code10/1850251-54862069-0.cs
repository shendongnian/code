    public class Portfolio
    {
        [XmlArray("fotos")]
        [XmlArrayItem("foto")]
        public List<Foto> Fotos { get; set; }
    }

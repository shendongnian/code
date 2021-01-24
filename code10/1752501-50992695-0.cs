    XmlSerializer serializer = new XmlSerializer(typeof(Teklif));
    using (FileStream fileStream = new FileStream(filename, FileMode.Open))
    {
         Teklif result = (Teklif)serializer.Deserialize(fileStream);
    }
    // Object model example
    [XmlRoot("teklif")]
    public class Teklif
    {
    	[XmlElement()]
    	public bilgiler bilgiler { get; set; }
    }
    
    public class bilgiler
    {
    	[XmlElement()] public string firma { get; set; }
    	[XmlElement()] public string aciklama { get; set; }
    	[XmlElement()] public string isim { get; set; }
    	[XmlElement()] public string telefon { get; set; }
    	[XmlElement()] public string eposta { get; set; }
    
    	[XmlArray()]
    	[XmlArrayItem("urun")]
    	public List<Urun> urunler { get; set; }
    }
    
    public class Urun
    {
    	[XmlElement()] public string resimDosyasi { get; set; }
    	[XmlElement()] public string aciklama { get; set; }
    	[XmlElement()] public string birim { get; set; }
    	[XmlElement()] public int miktar { get; set; }
    	[XmlElement()] public string toplam { get; set; }
    }

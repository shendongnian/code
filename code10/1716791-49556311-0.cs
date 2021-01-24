    [XmlRoot("cls_Yeni_Goc_Tespit_Formu")]
    public class YeniGocTespitFormu
    {
        [XmlElement("hastaBilgileri")]
        public List<HastaBilgileri> Items {get;} = new List<HastaBilgileri>();
        // ... etc
    }
    public class HastaBilgileri
    {
        public string TC {get;set;}
        public string AdSoyad {get;set;}
        // etc
    }

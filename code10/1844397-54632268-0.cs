    public class Foo
    {
        // the "real" list that takes <price1> elements
        [XmlElement("price1", typeof(PriceBonusData))]
        public List<PriceBonusData> PriceBonusDataList {get;} = new List<PriceBonusData>();
  
        // spoof a second list that handles <price2> elements (actually: the same list)
        [XmlElement("price2", typeof(PriceBonusData))]
        public List<PriceBonusData> PriceBonusDataList2 => PriceBonusDataList;
    
        // this disables serialization of PriceBonusDataList2 so we don't double up
        public bool ShouldSerializePriceBonusDataList2() => false;
    }

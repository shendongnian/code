    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/mInitechService")]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/mInitechService", IsNullable = false)]
    public class Product
    {
        [XmlArrayItem("SavingType", typeof(SavingType), IsNullable = false)]
        public SavingType[] AdvSaving;
        [XmlElement("effectiveDate")]
        public string effectiveDate;
    }
    [XmlType("SavingType")]
    public class SavingType
    {
        [XmlElement("savingsTypeName")]
        public string savingsTypeName;
        [XmlElement("savingsMinBal")]
        public string savingsMinBal;
        [XmlElement("savingNote")]
        public string savingNote;
		// FIXED
        //[XmlElement("Savings")]
        [XmlArray(ElementName = "Savings")]
		public Saving[] Savings;
    }
    [XmlType("Saving")]
    public class Saving
    {
        [XmlElement("name")]
        public string name;
		// FIXED
        [XmlElement("dailyBalance")]
        public string dailyBalance;
        [XmlElement("divRate")]
        public decimal divRate;
        [XmlElement("apy")]
        public decimal apy;
    }

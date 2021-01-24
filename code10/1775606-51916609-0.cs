    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/DictionarySerlization")]
    public class CashCounter
    {
        [DataMember]
        public BankNoteDictionary BankNote { get; set; }
    }
    [CollectionDataContract(ItemName = "MyItemName", KeyName = "MyKeyName", ValueName = "MyValueName",
        Namespace = "http://schemas.datacontract.org/2004/07/DictionarySerlization")]
    public class BankNoteDictionary : Dictionary<int, int>
    {
    }

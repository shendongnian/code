        [DataContract(Name = "Stamdata", Namespace = "http://schemas.datacontract.org/2004/07/a")]
        public class Stamdata
        {
            [DataMember]
            public DataList Liste { get; set; }
        }
        [CollectionDataContract(
            Namespace = "http://schemas.datacontract.org/2004/07/System.Collections.Generic",
            ItemName = "KeyValuePairOfStringDatagxNgnmsk")]
        public class DataList : List<KeyValuePair<string, Data>>
        {
            public DataList() : base() { }
            public DataList(IEnumerable<KeyValuePair<string, Data>> list) : base(list) { }
        }

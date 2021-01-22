    [DataContract]
    public class SerializableContingentOrder
    {
        [DataMember(Order=1)] public Guid SomeGuidData { get; set; }
        [DataMember(Order=2)] public decimal SomeDecimalData { get; set; }
        [DataMember(Order=3)] public MyEnumerationType1 EnumData1 { get; set; }
    }

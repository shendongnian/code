    [DataContract]
    public class MyDataClass
    {
      [DataMember(Name = "LabelInJson", IsRequired = false)]
      public string MyProperty { get; set; }
    }

    [DataContract(Name="GetMessage", Namespace="http://tempuri.org/")]
    public class GetMessage
    {
      [DataMember]
      public DataSet GetMessageResult {get;set;} // this will hold the DataSet
    }

    [DataContract]
    public class X
    {
      [DataMember]
      public Guid Id { get; private set; }
    }
    NetDataContractSerializer serializer = new NetDataContractSerializer();
    TextWriter tw = new StreamWriter(_location);
    serializer.Serialize(tw, obj);

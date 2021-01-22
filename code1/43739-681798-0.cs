    [DataContract]
    [KnownType(MyOne)]
    [KnownType(MyTwo)]
    public class MyObject
    {
        [DataMember]
        Guid ObjectID;
    }
    [DataContract]
    public class MyOne : MyObject
    {
        [DataMember]
        String StringOne;
    }
    [DataContract]
    public class MyTwo : MyObject
    {
        [DataMember]
        String StringTwo;
    }

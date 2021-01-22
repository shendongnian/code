    [DataContract]
    [KnownType(typeof(MyOne))]
    [KnownType(typeof(MyTwo))]
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

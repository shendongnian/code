    [DataContract]
    [KnownType(typeof(MyConcreteClass))]
    public interface IMyInterface {
    }
    [DataContract]
    public class MyConcreteClass : IMyInterface {
    }

    [DataContract]
    [KnownType(typeof(Guid))]
    [KnownType(typeof(SomeClass1))]
    [KnownType(typeof(SomeClass2))]
    public class MyType
    {
      private MyType(object obj) {
         Object = obj;
      }
    
      public static MyType FromSomeClass1(SomeClass1 c1) {
        return new MyType(c1);
      }
    
      public static MyType FromSomeClass2(SomeClass2 c2) {
        return new MyType(c2);
      }
    
      public static MyType FromGuid(Guid guid) {
        return new MyType(guid);
      }
      [DataMember]
      public object Object { get; private set; }
    }

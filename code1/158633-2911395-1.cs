    [CollectionDataContract(Name = "Classes")]
    public class Classes : List<MyClass>
    {
    }
    [DataContract(Name = "MyClass")]
    public class MyClass
    {
        [DataMember(Name="Id")]
        public int Id { get;set; }
    }

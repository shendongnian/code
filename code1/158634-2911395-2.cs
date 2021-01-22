    [CollectionDataContract(Name = "MyClasses1")]
    public class MyClassesOne : List<MyClass> { }
    [CollectionDataContract(Name = "MyClasses2")]
    public class MyClassesTwo : List<MyClass> { }
    [DataContract(Name = "Classes")]
    public class Classes {
        [DataMember] public MyClassesOne MyClasses1 { get; set; }
        [DataMember] public MyClassesTwo MyClasses2 { get; set; }
    }

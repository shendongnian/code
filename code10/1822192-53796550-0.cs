    public class SomeEntity
    {
        public int SomeEntityID {get;set;}
        public string Message {get;set;}
        public MyClassID {get;set;}
    }
    public class MyClass
    {
        public int MyClassID {get;set;}
        public object SomeProperty {get;set;}
        public List<SomeEntity> ListOfSomeEntity {get;set;}
    } 

    public class MyType : List<MyItemType>
    {
        public string Name {get;set;}
    }
    public class MyType
    {
        public string Name {get;set;}
        public List<MyItemType> Items {get;set;}
    }

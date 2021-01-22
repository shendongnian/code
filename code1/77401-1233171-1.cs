    public class MyType : List<MyItemType> // or BindingList<...>
    {
        public string Name {get;set;}
    }
    public class MyType
    {
        public string Name {get;set;}
        public List<MyItemType> Items {get;set;} // or BindingList<...>
    }

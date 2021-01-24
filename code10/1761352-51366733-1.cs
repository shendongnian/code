    public class MyType
    {
        public List<T> Prop1 { get; set; }
        public List<T> Prop2 { get; set; }
        public List<T> Prop3 { get; set; }
    }
    
    public static MyType Method()
    {
        return new MyType { Prop1 = list1, Prop2 = list2 ,Prop3 = list3};
    }

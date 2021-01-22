    private interface MyCollInterface1 : ICollection<int> { }
    private interface MyCollInterface2<T> : ICollection<T> { }
    private class MyCollType1 : MyCollInterface1 { ... }
    private class MyCollType2 : MyCollInterface2<int> { ... }
    private class MyCollType3<T> : MyCollInterface2<T> { ... }
    
    private class MyT
    {
        public ICollection<int> IntCollection { get; set; }
        public List<int> IntList { get; set; }
        public MyCollInterface1 iColl1 { get; set; }
        public MyCollInterface2<int> iColl2 { get; set; }
        public MyCollType1 Coll1 { get; set; }
        public MyCollType2 Coll2 { get; set; }
        public MyCollType3<int> Coll3 { get; set; }
        public string StringProp { get; set; }
    }

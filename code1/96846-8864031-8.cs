    private interface IMyCollInterface1 : ICollection<int> { }
    private interface IMyCollInterface2<T> : ICollection<T> { }
    private class MyCollType1 : IMyCollInterface1 { ... }
    private class MyCollType2 : IMyCollInterface2<int> { ... }
    private class MyCollType3<T> : IMyCollInterface2<T> { ... }
    
    private class MyT
    {
        public ICollection<int> IntCollection { get; set; }
        public List<int> IntList { get; set; }
        public IMyCollInterface1 iColl1 { get; set; }
        public IMyCollInterface2<int> iColl2 { get; set; }
        public MyCollType1 Coll1 { get; set; }
        public MyCollType2 Coll2 { get; set; }
        public MyCollType3<int> Coll3 { get; set; }
        public string StringProp { get; set; }
    }

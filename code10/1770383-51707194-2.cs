    public class MywebServiceInputDetail
    {
        public MyDatalst MyDatalst { get; set; }
    }
    public class MyDatalst
    {
        public List<MyStruct> MyData { get; set; }
    }
    public struct MyStruct
    {
        public string name;
        public string id;
        public string SomeRefVal;
    }

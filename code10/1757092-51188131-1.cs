    class Program
    {
        static void Main(string[] args)
        {
            MyClass myObj = new MyClass();
            FooBar(myObj);
        }
        public static void FooBar(object sender)
        {
            Type t = typeof(MyClass);
            var info = t.GetField("deal",BindingFlags.NonPublic | BindingFlags.Instance);
            var dealObject = info?.GetValue(sender);
            var dealListObj = ((DealList) dealObject)?.dealList;
        }
    }
    public class MyClass
    {
        private DealList deal = new DealList();
        public void Foo() { }
    }
    public class DealList
    {
        public List<int> dealList = new List<int>() {2,3};
    }

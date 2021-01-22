    public class MyCustomClass
    {
        public int Int1 { get; set; }
    }
    public class MyCustomList : List<MyCustomClass>, ISomeInterface
    {
        public MyCustomList() : base() { }
        public MyCustomList(IEnumerable<MyCustomClass> coll) : base(coll) { }
    }
    public interface ISomeInterface : IEnumerable<MyCustomClass>
    {
    }
    public class MyDerivedCustomList : MyCustomList, ISomeInterface
    {
        public MyDerivedCustomList() : base() { }
        public MyDerivedCustomList(IEnumerable<MyCustomClass> coll) : base(coll) { }
    }
    public static class MyExtensions
    {
        /// <summary>
        /// Where(x => x.Int1 > 2)
        /// </summary>
        public static IEnumerable<MyCustomClass> Where(this MyCustomList myList, Func<MyCustomClass, bool> predicate)
        {
            return new MyCustomList(Enumerable.Where(myList, predicate).Where(x => x.Int1 > 2));
        }
        /// <summary>
        /// Where(x => x.Int1 > 3)
        /// </summary>
        public static IEnumerable<MyCustomClass> Where(this ISomeInterface myList, Func<MyCustomClass, bool> predicate)
        {
            return new MyCustomList(Enumerable.Where(myList, predicate).Where(x => x.Int1 > 3));
        }
    }
